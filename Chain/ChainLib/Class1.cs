using System;
using System.Collections.Generic;
using System.Drawing;

namespace ChainLib
{
    public class TrainSob
    {
        public int size;
        public int x;
        public Bitmap pic;

        public TrainSob(int s, int x, Bitmap pic)
        {
            this.x = x;
            size = s;
            this.pic = pic;
        }
        public void move()
        {
            x-= 5;
        }
    }

    public interface Train
    {
        void NextTo(Train ts);
        void Req(TrainSob ts);
    }

    public class loco : Train
    {
        protected Train next;
        public List<TrainSob> tts = new List<TrainSob>();

        public void NextTo(Train t)
        {
            next = t;
        }

        public virtual void Req(TrainSob ts)
        {
            if (next != null)
            {
                next.Req(ts);
            }
        }
    }
    public class vagon1 : loco
    {
        public override void Req(TrainSob ts)
        {
            if (ts.size == 1)
            {
                tts.Add(ts);
            }
            else
            {
                next.Req(ts);
            }
        }
    }

    public class vagon2 : loco
    {
        public override void Req(TrainSob ts)
        {
            if (ts.size == 2)
            {
                tts.Add(ts);
            }
            else
            {
                next.Req(ts);
            }
        }
    }
}
