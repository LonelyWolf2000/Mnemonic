using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mnemonic.Model
{
    public enum ModeTest
    {
        Options,
        Writen,
        RandomMode      // Из представленных выше вариантов
    }

    public enum ModeRepeat 
    {
        Twice_a_Day,
        Once_a_Day,
        Every_Other_Day,
        Once_a_Week,
        Custom          // Опция задания пользовательского интервала
    }
    public class DataObject
    {
        private bool completed;                     // Галочка "Изучено"

        private string question;                    // Изучаемый вопрос
        private string subject;                     // Предмет/область к которой относится запись
        private string theme;                       // Тема
        private string term;                        // Термин, вопрос и тп...
        private string definition;                  // Определение, ответ...
        private Dictionary<string, string> images;  // Массив ссылок на графические материалы
        private Dictionary<string, string> audios;  // Массив ссылок на аудио материалы

        private int rating;                         // Оценка от 0 до 10
        private int previousRating;                 // Предыдущая оценка
        private DateTime lastRepeat;                // Дата последнего вызова записи для тестирования
        private DateTime repeatTime;                // Интервал повторения в зависимости от режима повторения
        private ModeRepeat modeRepeat;              // Режим повторения
        private ModeTest modeTest;                  // Режим тестирования

        public bool Completed
        {
            get
            {
                return completed;
            }

            set
            {
                completed = value;
            }
        }

        public string Question
        {
            get
            {
                return question;
            }

            set
            {
                question = value;
            }
        }

        public string Subject
        {
            get
            {
                return subject;
            }

            set
            {
                subject = value;
            }
        }

        public string Theme
        {
            get
            {
                return theme;
            }

            set
            {
                theme = value;
            }
        }

        public string Term
        {
            get
            {
                return term;
            }

            set
            {
                term = value;
            }
        }

        public string Definition
        {
            get
            {
                return definition;
            }

            set
            {
                definition = value;
            }
        }

        public int Rating
        {
            get
            {
                return rating;
            }

            set
            {
                rating = value;
            }
        }

        public int PreviousRating
        {
            get
            {
                return previousRating;
            }

            set
            {
                previousRating = value;
            }
        }

        public ModeTest ModeTest
        {
            get
            {
                return modeTest;
            }

            set
            {
                modeTest = value;
            }
        }

        public ModeRepeat ModeRepeat
        {
            get
            {
                return modeRepeat;
            }

            set
            {
                if (value == ModeRepeat.Twice_a_Day)
                    this.RepeatTime = new DateTime(1, 1, 1, 5, 0, 0);
                else if (value == ModeRepeat.Once_a_Day)
                    this.RepeatTime = new DateTime(1, 1, 1, 0, 0, 0);
                else if (value == ModeRepeat.Every_Other_Day)
                    this.RepeatTime = new DateTime(1, 1, 2, 0, 0, 0);
                else if (value == ModeRepeat.Once_a_Week)
                    this.RepeatTime = new DateTime(1, 1, 7, 0, 0, 0);

                modeRepeat = value;
            }
        }
        
        public DateTime RepeatTime
        {
            get
            {
                return repeatTime;
            }

            set
            {
                repeatTime = value;
            }
        }

        public Dictionary<string, string> Images
        {
            get { return images; }
            set { images = value; }
        }

        public Dictionary<string, string> Audios
        {
            get { return audios; }
            set { audios = value; }
        }

        public DateTime LastRepeat
        {
            get
            {
                return lastRepeat;
            }

            set
            {
                lastRepeat = value;
            }
        }

        public DataObject()
        {
            this.Completed = false;
            this.Question = null;
            this.Subject = null;
            this.Theme = null;
            this.Term = null;
            this.Definition = null;

            this.Rating = 0;
            this.PreviousRating = 0;
            this.LastRepeat = new DateTime();

            this.ModeRepeat = ModeRepeat.Twice_a_Day;
            this.ModeTest = ModeTest.Writen;
        }
    }
}
