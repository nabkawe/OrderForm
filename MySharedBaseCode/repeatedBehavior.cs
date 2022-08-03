using System.Windows.Forms;

namespace sharedCode
{
    public static class repeatedBehavior
    {
        /// <summary>
        /// Custom Yes No MessageBox.
        /// </summary>
        /// <param name="Your Message">your Message</param>
        /// <param name="Your Title">your Message Title</param>
        /// <returns>True if user presses Yes, false otherwise</returns>
        public static bool AreYouSure(string yourMessage, string YourTitle)
        {
            DialogResult result = MessageBox.Show(yourMessage, YourTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                return true;
            }
            else return false;



        }
    }
}
