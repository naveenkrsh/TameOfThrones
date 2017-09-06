using System;
namespace Core.Sources
{
    public class BallotMessage : ICloneable
    {
        public BallotMessage(Kingdom sender,Kingdom receiver,string message)
        {
            Sender = sender;
            Receiver = receiver;
            Message = message;
        }
        public Kingdom Sender { get; }
        public Kingdom Receiver { get; }
        public string Message { get; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}