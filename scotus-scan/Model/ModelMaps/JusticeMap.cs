using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scotus_scan.Model.ModelMaps
{
    public class JusticeMap
    {
        public static string GetJusticeName(int justiceId)
        {
            switch (justiceId)
            {
                case 1:
                    return "Jay, John";
                case 2:
                    return "Rutledge, John";
                case 3:
                    return "Cushing, William";
                case 4:
                    return "Wilson, James";
                case 5:
                    return "Blair, John";
                case 6:
                    return "Iredell, James";
                case 7:
                    return "Johnson, Thomas";
                case 8:
                    return "Paterson, William";
                case 9:
                    return "Rutledge, John";
                case 10:
                    return "Chase, Samuel";
                case 11:
                    return "Ellsworth, Oliver";
                case 12:
                    return "Washington, Bushrod";
                case 13:
                    return "Moore, Alfred";
                case 14:
                    return "Marshall, John";
                case 15:
                    return "Johnson, William";
                case 16:
                    return "Livingston, Henry";
                case 17:
                    return "Todd, Thomas";
                case 18:
                    return "Duvall, Gabriel";
                case 19:
                    return "Story, Joseph";
                case 20:
                    return "Thompson, Smith";
                case 21:
                    return "Trimble, Robert";
                case 23:
                    return "Baldwin, Henry";
                case 24:
                    return "Wayne, James";
                case 25:
                    return "Taney, Roger";
                case 26:
                    return "Barbour, Philip";
                case 27:
                    return "Catron, John";
                case 28:
                    return "McKinley, John";
                case 29:
                    return "Daniel, Peter";
                case 30:
                    return "Nelson, Samuel";
                case 31:
                    return "Woodbury, Levi";
                case 32:
                    return "Grier, Robert";
                case 33:
                    return "Curtis, Benjamin";
                case 34:
                    return "Campbell, John";
                case 35:
                    return "Clifford, Nathan";
                case 36:
                    return "Swayne, Noah";
                case 37:
                    return "Miller, Samuel";
                case 38:
                    return "Davis, David";
                case 39:
                    return "Field, Stephen";
                case 40:
                    return "Chase, Salmon";
                case 41:
                    return "Strong, William";
                case 42:
                    return "Bradley, Joseph";
                case 43:
                    return "Hunt, Ward";
                case 44:
                    return "Waite, Morrison";
                case 45:
                    return "Harlan, John";
                case 46:
                    return "Woods, William";
                case 47:
                    return "Matthews, Stanley";
                case 48:
                    return "Gray, Horace";
                case 49:
                    return "Blatchford, Samuel";
                case 50:
                    return "Lamar, Lucius";
                case 51:
                    return "Fuller, Melville";
                case 52:
                    return "Brewer, David";
                case 53:
                    return "Brown, Henry";
                case 54:
                    return "Shiras, George";
                case 55:
                    return "Jackson, Howell";
                case 56:
                    return "White, Edward";
                case 57:
                    return "Peckham, Rufus";
                case 58:
                    return "McKenna, Joseph";
                case 59:
                    return "Holmes, Oliver";
                case 60:
                    return "Day, William";
                case 61:
                    return "Moody, William";
                case 62:
                    return "Lurton, Horace";
                case 63:
                    return "Hughes, Charles";
                case 64:
                    return "Van Devanter, Willis";
                case 65:
                    return "Lamar, Joseph";
                case 66:
                    return "Pitney, Mahlon";
                case 67:
                    return "McReynolds, James";
                case 68:
                    return "Brandeis, Louis";
                case 69:
                    return "Clarke, John";
                case 70:
                    return "Taft, William";
                case 71:
                    return "Sutherland, George";
                case 72:
                    return "Butler, Pierce";
                case 73:
                    return "Sanford, Edward";
                case 74:
                    return "Stone, Harlan";
                case 75:
                    return "Hughes, Charles";
                case 76:
                    return "Roberts, Owen";
                case 77:
                    return "Cardozo, Benjamin";
                case 78:
                    return "Black, Hugo";
                case 79:
                    return "Reed, Stanley";
                case 80:
                    return "Frankfurter, Felix";
                case 81:
                    return "Douglas, William";
                case 82:
                    return "Murphy, Francis";
                case 83:
                    return "Byrnes, James";
                case 84:
                    return "Jackson, Robert";
                case 85:
                    return "Rutledge, Wiley";
                case 86:
                    return "Burton, Harold";
                case 87:
                    return "Vinson, Fred";
                case 88:
                    return "Clark, Tom";
                case 89:
                    return "Minton, Sherman";
                case 90:
                    return "Warren, Earl";
                case 91:
                    return "Harlan, John";
                case 92:
                    return "Brennan, William";
                case 93:
                    return "Whittaker, Charles";
                case 94:
                    return "Stewart, Potter";
                case 95:
                    return "White, Byron";
                case 96:
                    return "Goldberg, Arthur";
                case 97:
                    return "Fortas, Abe";
                case 98:
                    return "Marshall, Thurgood";
                case 99:
                    return "Burger, Warren";
                case 100:
                    return "Blackmun, Harry";
                case 101:
                    return "Powell, Lewis";
                case 102:
                    return "Rehnquist, William";
                case 103:
                    return "Stevens, John";
                case 104:
                    return "O'Connor, Sandra";
                case 105:
                    return "Scalia, Antonin";
                case 106:
                    return "Kennedy, Anthony";
                case 107:
                    return "Souter, David";
                case 108:
                    return "Thomas, Clarence";
                case 109:
                    return "Ginsburg, Ruth";
                case 110:
                    return "Breyer, Stephen";
                case 111:
                    return "Roberts, John";
                case 112:
                    return "Alito, Samuel";
                case 113:
                    return "Sotomayor, Sonia";
                case 114:
                    return "Kagan, Elena";
                case 115:
                    return "Gorsuch, Neil";
                case 116:
                    return "Kavanaugh, Brett";
                default:
                    return "No Justice Found";
            }
        }
        public static string GetJusticeLastName(int justiceId)
        {
            switch (justiceId)
            {
                case 1:
                    return "Jay";
                case 2:
                    return "Rutledge, John";
                case 3:
                    return "Cushing, William";
                case 4:
                    return "Wilson, James";
                case 5:
                    return "Blair, John";
                case 6:
                    return "Iredell, James";
                case 7:
                    return "Johnson, Thomas";
                case 8:
                    return "Paterson, William";
                case 9:
                    return "Rutledge, John";
                case 10:
                    return "Chase, Samuel";
                case 11:
                    return "Ellsworth, Oliver";
                case 12:
                    return "Washington, Bushrod";
                case 13:
                    return "Moore, Alfred";
                case 14:
                    return "Marshall, John";
                case 15:
                    return "Johnson, William";
                case 16:
                    return "Livingston, Henry";
                case 17:
                    return "Todd, Thomas";
                case 18:
                    return "Duvall, Gabriel";
                case 19:
                    return "Story, Joseph";
                case 20:
                    return "Thompson, Smith";
                case 21:
                    return "Trimble, Robert";
                case 23:
                    return "Baldwin, Henry";
                case 24:
                    return "Wayne, James";
                case 25:
                    return "Taney, Roger";
                case 26:
                    return "Barbour, Philip";
                case 27:
                    return "Catron, John";
                case 28:
                    return "McKinley, John";
                case 29:
                    return "Daniel, Peter";
                case 30:
                    return "Nelson, Samuel";
                case 31:
                    return "Woodbury, Levi";
                case 32:
                    return "Grier, Robert";
                case 33:
                    return "Curtis, Benjamin";
                case 34:
                    return "Campbell, John";
                case 35:
                    return "Clifford, Nathan";
                case 36:
                    return "Swayne, Noah";
                case 37:
                    return "Miller, Samuel";
                case 38:
                    return "Davis, David";
                case 39:
                    return "Field, Stephen";
                case 40:
                    return "Chase, Salmon";
                case 41:
                    return "Strong, William";
                case 42:
                    return "Bradley, Joseph";
                case 43:
                    return "Hunt, Ward";
                case 44:
                    return "Waite, Morrison";
                case 45:
                    return "Harlan, John";
                case 46:
                    return "Woods, William";
                case 47:
                    return "Matthews, Stanley";
                case 48:
                    return "Gray, Horace";
                case 49:
                    return "Blatchford, Samuel";
                case 50:
                    return "Lamar, Lucius";
                case 51:
                    return "Fuller, Melville";
                case 52:
                    return "Brewer, David";
                case 53:
                    return "Brown, Henry";
                case 54:
                    return "Shiras, George";
                case 55:
                    return "Jackson, Howell";
                case 56:
                    return "White, Edward";
                case 57:
                    return "Peckham, Rufus";
                case 58:
                    return "McKenna, Joseph";
                case 59:
                    return "Holmes, Oliver";
                case 60:
                    return "Day, William";
                case 61:
                    return "Moody, William";
                case 62:
                    return "Lurton, Horace";
                case 63:
                    return "Hughes, Charles";
                case 64:
                    return "Van Devanter, Willis";
                case 65:
                    return "Lamar, Joseph";
                case 66:
                    return "Pitney, Mahlon";
                case 67:
                    return "McReynolds, James";
                case 68:
                    return "Brandeis, Louis";
                case 69:
                    return "Clarke, John";
                case 70:
                    return "Taft, William";
                case 71:
                    return "Sutherland, George";
                case 72:
                    return "Butler, Pierce";
                case 73:
                    return "Sanford, Edward";
                case 74:
                    return "Stone, Harlan";
                case 75:
                    return "Hughes, Charles";
                case 76:
                    return "Roberts, Owen";
                case 77:
                    return "Cardozo, Benjamin";
                case 78:
                    return "Black, Hugo";
                case 79:
                    return "Reed, Stanley";
                case 80:
                    return "Frankfurter, Felix";
                case 81:
                    return "Douglas, William";
                case 82:
                    return "Murphy, Francis";
                case 83:
                    return "Byrnes, James";
                case 84:
                    return "Jackson, Robert";
                case 85:
                    return "Rutledge, Wiley";
                case 86:
                    return "Burton, Harold";
                case 87:
                    return "Vinson, Fred";
                case 88:
                    return "Clark, Tom";
                case 89:
                    return "Minton, Sherman";
                case 90:
                    return "Warren, Earl";
                case 91:
                    return "Harlan, John";
                case 92:
                    return "Brennan, William";
                case 93:
                    return "Whittaker, Charles";
                case 94:
                    return "Stewart, Potter";
                case 95:
                    return "White, Byron";
                case 96:
                    return "Goldberg, Arthur";
                case 97:
                    return "Fortas, Abe";
                case 98:
                    return "Marshall, Thurgood";
                case 99:
                    return "Burger";
                case 100:
                    return "Blackmun";
                case 101:
                    return "Powell";
                case 102:
                    return "Rehnquist";
                case 103:
                    return "Stevens";
                case 104:
                    return "O'Connor";
                case 105:
                    return "Scalia";
                case 106:
                    return "Kennedy";
                case 107:
                    return "Souter";
                case 108:
                    return "Thomas";
                case 109:
                    return "Ginsburg";
                case 110:
                    return "Breyer";
                case 111:
                    return "Roberts";
                case 112:
                    return "Alito";
                case 113:
                    return "Sotomayor";
                case 114:
                    return "Kagan";
                case 115:
                    return "Gorsuch";
                case 116:
                    return "Kavanaugh";
                default:
                    return "No Justice Found";
            }
        }
    }
}
