using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMusic.LogicClasses.InteractionWithFileSystem
{
    internal class OGGFormat : IFileFormat
    {
        string IFileFormat.GetFormat() => ".ogg";
    }
}
