using System.Windows.Forms;

namespace OrderForm
{
    public static class repeatedBehavior
    {
        /// <summary>
        /// Custom Yes No MessageBox.
        /// </summary>
        /// <param name="yourMessage">your Message</param>
        /// <param name="yourTitle">your Message Title</param>
        /// <returns>True if user presses Yes, false otherwise</returns>
        public static bool AreYouSure(string yourMessage, string yourTitle)
        {
            DialogResult result = MessageForm.SHOW(yourMessage, yourTitle, "نعم","لا");
            if (result == DialogResult.Yes)
            {
                return true;
            }

            else {  return false; }
        }
    }
}
