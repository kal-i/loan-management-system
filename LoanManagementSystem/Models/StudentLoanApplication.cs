using LoanManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoanManagementSystem.Models
{
    internal class StudentLoanApplication : LoanApplication
    {
        public override void ProcessApplication()
        {
            MessageBox.Show($"𝐏𝐫𝐨𝐜𝐞𝐬𝐬𝐢𝐧𝐠 𝐒𝐭𝐮𝐝𝐞𝐧𝐭 𝐋𝐨𝐚𝐧 𝐀𝐩𝐩𝐥𝐢𝐜𝐚𝐭𝐢𝐨𝐧\n" +
                $"𝙲𝚞𝚜𝚝𝚘𝚖𝚎𝚛 𝙸𝙳: \t{Client.ID}\n" +
                $"𝙻𝚘𝚊𝚗 𝚃𝚢𝚙𝚎 𝙸𝙳: \t{LoanTypeId}\n" +
                $"𝙰𝚙𝚙𝚕𝚒𝚌𝚊𝚝𝚒𝚘𝚗 𝙳𝚊𝚝𝚎: \t{ApplicationDate.ToLongDateString()}\n" +
                $"𝚂𝚝𝚊𝚝𝚞𝚜: \t{Status}",
                "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
