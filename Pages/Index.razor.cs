using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MudBlazor;
using QRCoder;

namespace GeneradorQR.Pages;

    public partial class Index
    {
        MudForm urlSubmit;
        public string? SubmittedUrl {get; set;}

        public string? QrCodeText { get; set; }


        private async Task SubmitUrl()
        {
            await urlSubmit.Validate();
            if(urlSubmit.IsValid)   
                GeneradorQR();
        }
        protected void GeneradorQR(){
            QRCodeGenerator qrGenerador =  new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerador.CreateQrCode(SubmittedUrl, QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
            byte[] qrCodeAsByteArr = qrCode.GetGraphic(20);
            var ms = new MemoryStream(qrCodeAsByteArr);
            QrCodeText = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
            SubmittedUrl = String.Empty;

        }
    }
