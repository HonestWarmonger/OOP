using System;
using System.IO;
using Lab31V11.Domain;

namespace Lab31V11.IO
{
    /// Працюємо з одним файлом-джерелом (Student/Seller/Gardener).
    public sealed class TextFileDataSource
    {
        private readonly string _path;
        public TextFileDataSource(string path) { _path = path; }

        public void SaveAll(Student[] students, int studentCount,
                            Seller[] sellers, int sellerCount,
                            Gardener[] gardeners, int gardenerCount)
        {
            using var w = new StreamWriter(_path, false);

            for (int i = 0; i < studentCount; i++)
            {
                var s = students[i];
                w.WriteLine($"Student {s.FirstName}{s.LastName}");
                w.WriteLine("{");
                w.WriteLine($"  \"firstname\": \"{s.FirstName}\",");
                w.WriteLine($"  \"lastname\": \"{s.LastName}\",");
                w.WriteLine($"  \"studentId\": \"{s.StudentId}\",");
                w.WriteLine($"  \"course\": \"{s.Course}\",");
                w.WriteLine($"  \"gender\": \"{s.Gender}\"{(s.LivesInDorm ? "," : "")}");
                if (s.LivesInDorm)
                    w.WriteLine($"  \"dorm\": \"{s.DormNumber}-{s.DormRoom}\""); // формат №гурт-кiмната
                else
                    w.WriteLine($"  \"city\": \"{s.City}\"");
                w.WriteLine("};");
            }

            for (int i = 0; i < sellerCount; i++)
            {
                var s = sellers[i];
                w.WriteLine($"Seller {s.FirstName}{s.LastName}");
                w.WriteLine("{");
                w.WriteLine($"  \"firstname\": \"{s.FirstName}\",");
                w.WriteLine($"  \"lastname\": \"{s.LastName}\",");
                w.WriteLine($"  \"shop\": \"{s.Shop}\"");
                w.WriteLine("};");
            }

            for (int i = 0; i < gardenerCount; i++)
            {
                var g = gardeners[i];
                w.WriteLine($"Gardener {g.FirstName}{g.LastName}");
                w.WriteLine("{");
                w.WriteLine($"  \"firstname\": \"{g.FirstName}\",");
                w.WriteLine($"  \"lastname\": \"{g.LastName}\",");
                w.WriteLine($"  \"area\": \"{g.Area}\"");
                w.WriteLine("};");
            }
        }

        public void LoadAll(Student[] students, out int studentCount,
                            Seller[] sellers, out int sellerCount,
                            Gardener[] gardeners, out int gardenerCount)
        {
            studentCount = sellerCount = gardenerCount = 0;
            if (!File.Exists(_path)) return;

            using var r = new StreamReader(_path);
            string line;
            while ((line = ReadNonEmpty(r)) != null)
            {
                var header = line.Trim();
                var sp = header.IndexOf(' ');
                if (sp <= 0) throw new InvalidDataException("Bad header: " + header);
                var type = header[..sp];

                string block = ReadBlock(r);
                Parse(block, out string first, out string last,
                      out string studentId, out string courseStr,
                      out string genderStr, out string dorm, out string city,
                      out string shop, out string area);

                switch (type)
                {
                    case "Student":
                        {
                            int course = SafeInt(courseStr, 1);
                            var g = ParseGender(genderStr);
                            var s = new Student(first, last, studentId, course, g);
                            if (!string.IsNullOrWhiteSpace(dorm))
                            {
                                // формат "№-кiмната"
                                var parts = dorm.Split('-');
                                int dormNo = SafeInt(parts[0], 0);
                                var room = parts.Length > 1 ? parts[1] : "";
                                s.SetDorm(dormNo, room);
                            }
                            else s.SetCity(city ?? "");
                            students[studentCount++] = s;
                        }
                        break;

                    case "Seller":
                        sellers[sellerCount++] = new Seller(first, last, shop ?? "");
                        break;

                    case "Gardener":
                        gardeners[gardenerCount++] = new Gardener(first, last, area ?? "");
                        break;

                    default: throw new InvalidDataException("Unknown type: " + type);
                }
            }
        }

        private static string ReadNonEmpty(StreamReader r)
        {
            string s;
            while ((s = r.ReadLine()) != null)
            {
                s = s.Trim();
                if (s.Length == 0) continue;
                return s;
            }
            return null;
        }

        private static string ReadBlock(StreamReader r)
        {
            string open = ReadNonEmpty(r);
            if (open == null || !open.StartsWith("{")) throw new InvalidDataException("Expected '{'");
            string acc = "", line;
            while ((line = r.ReadLine()) != null)
            {
                if (line.Trim() == "};") break;
                acc += line + "\n";
            }
            return acc;
        }

        private static void Parse(string block,
            out string first, out string last,
            out string studentId, out string course, out string gender,
            out string dorm, out string city, out string shop, out string area)
        {
            first = last = studentId = course = gender = dorm = city = shop = area = null;

            var lines = block.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                var raw = lines[i].Trim().TrimEnd(',');
                if (raw.Length == 0) continue;
                int c = raw.IndexOf(':'); if (c <= 0) continue;
                var k = raw[..c].Trim().Trim('"');
                var v = raw[(c + 1)..].Trim().Trim('"');

                switch (k)
                {
                    case "firstname": first = v; break;
                    case "lastname": last = v; break;
                    case "studentId": studentId = v; break;
                    case "course": course = v; break;
                    case "gender": gender = v; break;
                    case "dorm": dorm = v; break;
                    case "city": city = v; break;
                    case "shop": shop = v; break;
                    case "area": area = v; break;
                }
            }
        }

        private static int SafeInt(string s, int defVal) => int.TryParse(s, out var x) ? x : defVal;

        private static Gender ParseGender(string s)
        {
            if (string.Equals(s, "Male")) return Gender.Male;
            if (string.Equals(s, "Female")) return Gender.Female;
            return Gender.Unknown;
        }
    }
}
