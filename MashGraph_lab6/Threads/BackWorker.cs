using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;

namespace MashGraph_lab6.Threads
{
    public delegate void ExceptionHandler(Exception e);

    public class BackWorker
    {
        private Thread mainThread = null;
        private int stackSize = 0;
        private System.Windows.Forms.Timer workEndChecker = null;
        private bool executionEnd = false;
        private Exception exception = null;
        private object SynchronizationObject = null;

        public event EventHandler DoWork;
        public event EventHandler RunWorkerCompleted;
        public event EventHandler ProgressChanged;
        public event ExceptionHandler ExceptionCatched;

        public BackWorker(int stackSize)
        {
            this.stackSize = stackSize;
        }

        public BackWorker()
        {
        }

        #region Private Functions
        private void CreateTimer()
        {
            if (workEndChecker == null)
            {
                workEndChecker = new System.Windows.Forms.Timer();
                workEndChecker.Interval = 100;
                workEndChecker.Tick += new EventHandler(CheckThreadState);
                if (ProgressChanged != null)
                    workEndChecker.Tick += ProgressChanged;
            }
        }

        private void CreateThread(ParameterizedThreadStart start)
        {
            if (stackSize == 0)
                mainThread = new Thread(start);
            else
                mainThread = new Thread(start, stackSize);
            mainThread.IsBackground = true;
            CreateTimer();
        }

        private void CheckThreadState(object parameter, EventArgs e)
        {
            if (executionEnd)
            {
                OnWorkCompleted(parameter, e);
            }
        }

        private void ExecutionWrapper(object parameter)
        {    
            while (true)
            {
                executionEnd = false;
                if (parameter != SynchronizationObject)
                    parameter = SynchronizationObject;

                try
                {
                    try
                    {
                        DoWork(parameter, null);
                    }
                    catch (Exception ex)
                    {
                        exception = ex;
                    }
                }
                catch (ThreadAbortException)
                {
                    exception = null;
                }
                finally
                {
                    executionEnd = true;
                }

                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadInterruptedException) { }
            }
        }

        private void OnWorkCompleted(object parameter, EventArgs e)
        {
            workEndChecker.Stop();
            if (exception != null)
            {
                Exception throwingException = exception;
                exception = null;
                if (ExceptionCatched != null)
                    ExceptionCatched(throwingException);
            }
            if (RunWorkerCompleted != null)
                RunWorkerCompleted(parameter, e);
        }

        #endregion

        public void RunWorkerAsync(object parameter)
        {
            if (mainThread == null)
                CreateThread(new ParameterizedThreadStart(ExecutionWrapper));
            workEndChecker.Start();
            SynchronizationObject = parameter;
            if ((mainThread.ThreadState & ThreadState.WaitSleepJoin) > 0)
                mainThread.Interrupt();
            else
                mainThread.Start(parameter);
        }

        public void CancelAsync()
        {
            mainThread.Abort();
            mainThread.Join();
            mainThread = null;
            OnWorkCompleted(null, null);
        }
    }
}
