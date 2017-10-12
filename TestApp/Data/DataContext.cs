using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

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

    public class Picture
    {
        public int Id { get; set; }
        public string Url { get; set; }
    }

    public class DataContext : DbContext
    {
        public IDbSet<Field> Fields { get; set; }
        public IDbSet<Picture> Pictures { get; set; }

        public IEnumerable<Field> GetFields()
        {
            if (!Fields.Any())
            {
                var picture = new Picture
                {
                    Url = "bill.jpeg"
                };
                Fields.Add(new Field
                {
                    Data = "454987",
                    Name = "телефон",
                    ValidationString = @"/^(\s*)?(\+)?([-_():= +]?\d[-_():= +] ?){ 10,14} (\s*)?$/",
                    X = 20,
                    Y = 20,
                    X1 = 200,
                    Y1 = 250,
                    X2 = 500,
                    Y2 = 300,
                    Picture = picture
                });
                Fields.Add(new Field
                {
                    Data = "вася",
                    Name = "грузополучатель",
                    X = 30,
                    Y = 90,
                    X1 = 450,
                    Y1 = 440,
                    X2 = 800,
                    Y2 = 500,
                    Picture = picture
                });
                Fields.Add(new Field
                {
                    Data = "12/12/2016",
                    Name = "дата",
                    ValidationString = @"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[-/.](19|20)\d\d",
                    X = 25,
                    Y = 130,
                    X1 = 1700,
                    Y1 = 900,
                    X2 = 1900,
                    Y2 = 1000,
                    Picture = picture
                });
                SaveChanges();
            }
            return Fields.Include(r => r.Picture).ToArray();
        }
    }
}