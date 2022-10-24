using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Application.Base
{
    /// <summary>
    /// OCR识别服务
    /// </summary>
    public abstract class BaseOcrService
    {
        protected FileInfo ImageFile { get; set; }

        protected BaseOcrService(FileInfo imageFile)
        {
            ImageFile = imageFile ?? throw new ArgumentNullException(nameof(imageFile));
        }

    }
}
