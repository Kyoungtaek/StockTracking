using System.Windows.Forms;

namespace StockTracking.Infrastructures
{
    public class General
    {
        public static bool IsNumber(KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                return true;
            }

            return false;
        }
    }
}
