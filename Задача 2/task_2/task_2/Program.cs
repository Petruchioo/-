using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    // Представим, что все классы в разных файлах
    public class Note
    {
        public int Id { get; }
        public string Title { get; }
        public bool IsCompleted { get; set; } = false;
        public Note(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }

    // лучше добавить интерфейсы сетодов рассписанных ниже

    public class NoteMemoryRepository //неочивидное название
    {
        public static readonly List<Note> Notes = new List<Note>();  // заменить public на private 
        public void CompleteNote(int id)
        {
            var note = Notes.FirstOrDefault(n => n.Id == id);
            if (note is null)
            {
                throw new Exception("Note not found exception"); //лучше пробрасывать кокретную ошибку, а не использовать общий класс
            }
            note.IsCompleted = true;
        }
        public void DeleteNote(int id)
        {
            var note = Notes.FirstOrDefault(n => n.Id == id);
            if (note is null)
            {
                throw new Exception("Note not found exception"); //лучше пробрасывать кокретную ошибку, а не использовать общий класс
            }
            Notes.Remove(note);
        }

        public void AddNote(Note note) 
        { 
            var a = Notes.FirstOrDefault(n => n.Id == note.Id); //не имфармативная переменная
            if (a != null) // нет проверки на дублирование названия записки
            {
                throw new Exception("Note already exists exception"); //лучше пробрасывать кокретную ошибку, а не использовать общий класс
            }
            Notes.Add(note);
        }

        public List<Note> GetNotes() => Notes;

        public Note GetNote(int id)
        {
            var note = Notes.FirstOrDefault(n => n.Id == id);
            if (note is null)
            {
                throw new Exception("Note not found exception"); //лучше пробрасывать кокретную ошибку, а не использовать общий класс
            }
            return note;
        }
    }
}
