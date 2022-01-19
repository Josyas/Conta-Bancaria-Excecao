using ContaBancariaExcecao.Entities.Exceptions;
using System.Globalization;
namespace ContaBancariaExcecao.Entities
{
    class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithDrawLimit { get; set; }
        public double ToWithDraw { get; set; }
        

        public Account(int number, string holder, double balance, double withDrawLimit, double toWithDraw)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithDrawLimit = withDrawLimit;
            ToWithDraw = toWithDraw;
          
        }
                       
        public void WithDraw(double toWithDraw)
        {
           if (ToWithDraw > WithDrawLimit)
           {
              throw new DomainException("The amount exceeds withdraw limit.");
           }
           if (ToWithDraw > Balance)
           {
                throw new DomainException("Not enough balance.");
           }
           ToWithDraw = toWithDraw - Balance;                                                                     
        }

        public override string ToString()
        {
            return "New Balance: " + ToWithDraw.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
