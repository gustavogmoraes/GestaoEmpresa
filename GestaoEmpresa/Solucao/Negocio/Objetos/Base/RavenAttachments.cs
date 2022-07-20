using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using KellermanSoftware.CompareNetObjects;
using NeoSmart.StreamCompare;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base
{
    public class RavenAttachments : IEquatable<RavenAttachments>
    {
        public List<string> AttachmentsNames { get; set; }

        [JsonIgnore]
        public Dictionary<string, Stream> FileStreams { get; set; }

        public bool Equals(RavenAttachments other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            var countEqual = AttachmentsNames.Count == other.AttachmentsNames.Count &&
                             FileStreams.Count == other.FileStreams?.Count;
            if (!countEqual)
            {
                return false;
            }

            var namesEqual = AttachmentsNames.SequenceEqual(other.AttachmentsNames);
            if (!namesEqual)
            {
                return false;
            }

            //// Bitmap comparison
            for (var i = 0; i < FileStreams.Count; i++)
            {
                var bitmapA = new Bitmap(FileStreams[$"Image-{i + 1}"]);
                var bitmapB = new Bitmap(other.FileStreams[$"Image-{i + 1}"]);

                if (!bitmapA.GetHash().SequenceEqual(bitmapB.GetHash()))
                {
                    return false;
                }
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((RavenAttachments) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AttachmentsNames, FileStreams);
        }
    }
}
