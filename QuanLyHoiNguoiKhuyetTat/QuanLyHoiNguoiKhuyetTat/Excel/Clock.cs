#region "Author"
/****************************************************************************************
 * Solution     : CUSC His Framework
 * Project code : APP1105
 * Author       : Dương Nguyễn Phú Cường
 * Company      : Cusc Software
 * Version      : 1.0.0.1
 * Created date : 29/03/2013
 ***************************************************************************************/
#endregion

using System;

namespace CuscLibrary.SystemDependencies
{
    internal static class Clock
    {
        /// <summary>
        /// Set a substitute (and fix) value for Now.  See <see cref="SubstituteForSystemDate"/>
        /// for usage example.
        /// </summary>
        public static DateTime? SubstituteForNow;

        public static DateTime Now
        {
            get { return (SubstituteForNow ?? DateTime.Now); }
        }
    }
}
