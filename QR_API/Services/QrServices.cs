using DAL.Context;
using Microsoft.AspNetCore.Components;

namespace QR_API.Services
{
    public class QrServices
    {
        private DataContext _context;
        public QrServices(DataContext context)
        {
            _context = context;
        }

        public void GeneraetQrCode(int eqeuipmentId)
        {
            
        }
    }
}
