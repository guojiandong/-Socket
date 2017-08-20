using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FormsCTF.Tools
{
    public class ThreadMulti
    {
        public delegate void DelegateComplete();
        public delegate void DelegateWork(int taskindex, int threadindex);

        public DelegateComplete CompleteEvent;
        public DelegateWork WorkMethod;


        private ManualResetEvent[] _resets;
        private int _taskCount = 0;
        private int _threadCount = 5;

        public ThreadMulti(int taskcount)
        {
            _taskCount = taskcount;
        }

        public ThreadMulti(int taskcount, int threadCount)
        {
            _taskCount = taskcount;
            _threadCount = threadCount;
        }

        public void Start()
        {
            if (_taskCount < _threadCount)
            {
                //任务数小于线程数的
                _resets = new ManualResetEvent[_taskCount];
                for (int j = 0; j < _taskCount; j++)
                {
                    _resets[j] = new ManualResetEvent(false);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(Work), new object[] { j, j });
                }
            }
            else
            {
                _resets = new ManualResetEvent[_threadCount];
                //任务数大于线程数 先把线程数的任务启动
                for (int i = 0; i < _threadCount; i++)
                {
                    _resets[i] = new ManualResetEvent(false);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(Work), new object[] { i, i });
                }
                //完成一个任务后在利用完成的那个线程执行下一个任务
                int receivereset = 0;
                receivereset = ManualResetEvent.WaitAny(_resets);
                for (int l = _threadCount; l < _taskCount; l++)
                {
                    _resets[receivereset].Reset();
                    ThreadPool.QueueUserWorkItem(new WaitCallback(Work), new object[] { l, receivereset });
                    receivereset = ManualResetEvent.WaitAny(_resets);
                }
            }

            ManualResetEvent.WaitAll(_resets);
            if (CompleteEvent != null)
            {
                CompleteEvent();
            }
        }

        public void Work(object arg)
        {
            int taskindex = int.Parse(((object[])arg)[0].ToString());
            int resetindex = int.Parse(((object[])arg)[1].ToString());
            if (WorkMethod != null)
            {
                WorkMethod(taskindex + 1, resetindex + 1);
            }
            _resets[resetindex].Set();
        }
    }
}
