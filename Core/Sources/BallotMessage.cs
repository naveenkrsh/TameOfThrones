using System;
namespace Core.Sources
{
    public class BallotMessage : ICloneable, IEquatable<BallotMessage>
    {
        public BallotMessage(Kingdom sender, Kingdom receiver, string message)
        {
            Sender = sender;
            Receiver = receiver;
            Message = message;
        }
        public Kingdom Sender { get; }
        public Kingdom Receiver { get; }
        public string Message { get; }
        public void SendMessageToReceivingKingdom()
        {
            if (this.Receiver.TryToWin(this.Message))
            {
                this.Sender.AddAllie(this.Receiver);
            }
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public override string ToString()
        {
            return this.Sender.ToString() +" "+ this.Receiver.ToString()+" "+this.Message;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public bool Equals(BallotMessage other)
        {
            return this.Receiver == other.Receiver
                    && this.Sender == other.Sender
                    && this.Message == other.Message;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            BallotMessage message = obj as BallotMessage;
            if (message == null)
                return false;
            else
                return Equals(message);
        }

        public static bool operator ==(BallotMessage operand1, BallotMessage operand2)
        {
            if (((object)operand1) == null || ((object)operand2) == null)
                return Object.Equals(operand1, operand2);

            return operand1.Equals(operand2);
        }

        public static bool operator !=(BallotMessage operand1, BallotMessage operand2)
        {
            if (((object)operand1) == null || ((object)operand2) == null)
                return !Object.Equals(operand1, operand2);

            return !(operand1.Equals(operand2));
        }
    }
}