using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Data
{
    public class Field
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public string ValidationString { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
        public int PictureId { get; set; }
        [ForeignKey("PictureId")]
        public Picture Picture { get; set; }

        public string PictureUrl => Picture?.Url;
        public double Width => X2 - X1;
        public double Height => Y2 - Y1;
    }
}