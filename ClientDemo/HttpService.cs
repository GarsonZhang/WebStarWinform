using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ClientDemo
{
    public class HttpService
    {
        private static HttpService _instance;
        public static HttpService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HttpService();
                }
                return _instance;
            }
        }

        private System.Net.HttpListener _listener = null;

        public bool startSta = false;

        /// <summary>
        /// 启动
        /// </summary>
        public void Start(string ip, int port)
        {
            Stop();


            List<string> httpPrefixes = new List<string>();
            httpPrefixes.Add("http://" + ip + ":" + port + "/" + "execute/");
            httpPrefixes.Add("http://" + ip + ":" + port + "/" + "check/");
            new Thread(new ThreadStart(delegate
            {
                _listener = new HttpListener();
                while (true)
                {
                    try
                    {
                        _listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
                        //_listener.Prefixes.Add(httpPrefixes0);
                        //_listener.Prefixes.Add(httpPrefixes1);
                        if (httpPrefixes != null)
                        {
                            foreach (string url in httpPrefixes)
                            {
                                _listener.Prefixes.Add(url);
                            }
                        }
                        _listener.Start();

                    }
                    catch (Exception ex)
                    {
                        startSta = false;
                        break;
                    }

                    //线程池
                    int minThreadNum;
                    int portThreadNum;
                    int maxThreadNum;
                    ThreadPool.GetMaxThreads(out maxThreadNum, out portThreadNum);
                    ThreadPool.GetMinThreads(out minThreadNum, out portThreadNum);
                    //ThreadPool.QueueUserWorkItem(new WaitCallback(TaskProc1), x);
                    try
                    {
                        while (true)
                        {
                            startSta = true;
                            //等待请求连接
                            //没有请求则GetContext处于阻塞状态
                            HttpListenerContext ctx = _listener.GetContext();

                            ThreadPool.QueueUserWorkItem(new WaitCallback(TaskProc), ctx);
                        }
                    }
                    catch
                    {
                        startSta = false;
                    }
                }
            })).Start();
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            if (_listener != null)
            {
                _listener.Stop();
                _listener.Close();
                _listener = null;
            }
        }

        /// <summary>
        /// 任务进
        /// </summary>
        /// <param name="obj"></param>
        void TaskProc(object obj)
        {
            HttpListenerContext ctx = (HttpListenerContext)obj;
            try
            {
                var url = ctx.Request.Url.AbsoluteUri;

                if ("/check".Equals(ctx.Request.Url.AbsolutePath, StringComparison.OrdinalIgnoreCase))
                {
                    ctx.Response.StatusCode = 200;
                    var data = new
                    {
                        status = 0,
                        message = "客户端已启动"
                    };
                    var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    var bytes = System.Text.Encoding.UTF8.GetBytes(jsonStr);
                    ctx.Response.ContentType = "application/json";
                    ctx.Response.OutputStream.Write(bytes, 0, bytes.Length);
                }
                if ("/execute".Equals(ctx.Request.Url.AbsolutePath, StringComparison.OrdinalIgnoreCase))
                {
                    string command = ctx.Request.Url.GetQuery("command");
                    switch (command)
                    {
                        case "openform1":
                            {

                            };
                            break;
                        case "openform2":
                            {
                            };
                            break;
                    }

                    //Stream stream = ctx.Request.InputStream;
                    //System.IO.StreamReader reader = new System.IO.StreamReader(stream, Encoding.UTF8);
                    //#region 
                    //string body = reader.ReadToEnd();
                    ////这里的body就是客户端发过来的数据
                    //var upRecord = Newtonsoft.Json.JsonConvert.DeserializeObject<UpEventRecord>(body);
                    //if (upRecord != null)
                    //{
                    //    Form1._Instance.InsertRecord(upRecord);
                    //}
                    //#endregion 

                    //stream.Close();
                }

                ctx.Response.Close();
                ctx = null;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }
    }

    public static class Extensions
    {
        public static string GetQuery(this System.Uri url, string name)
        {
            //url.Query 
            Regex reg = new Regex(name + "=(\\w+)", RegexOptions.IgnoreCase);
            var m = reg.Match(url.Query);
            if (m.Success)
            {
                return m.Groups[1].Value;
            }
            else
                return "";
        }
    }
}
