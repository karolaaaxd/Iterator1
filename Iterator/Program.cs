using System;
using System.Collections;
using System.Collections.Generic;


namespace Iterator
{
    class Program
    {
        class Slodycz
        {
            private string _smak;

            public Slodycz(string smak)
            {
                this._smak = smak;
            }


            public string Smak
            {
                get { return _smak; }
            }
        }
        interface RodzajeCiastek
        {
          SlodyczIterator CreateIterator();
        }


        class SlodyczCollection : RodzajeCiastek


        {
            private ArrayList _items = new ArrayList();

            public SlodyczeIterator CreateIterator()
            {
                return new SlodyczeIterator(this);
            }

            SlodyczIterator RodzajeCiastek.CreateIterator()
            {
                throw new NotImplementedException();
            }

            public int Count
            {
                get { return _items.Count; }
            }

            public object this[int index]
            {
                get { return _items[index]; }
                set { _items.Add(value); }
            }
        }
        interface SlodyczIterator
        {
            Slodycz Pierwszy();
            Slodycz Nastepny();
            bool Zakonczenie { get; }
            Slodycz AktualnySmak { get; }
        }

      
        class SlodyczeIterator : SlodyczIterator
        {
            private SlodyczCollection _slodycz;
            private int _aktualny = 0;
            private int _poczatek = 1;

            public SlodyczeIterator(SlodyczCollection zelki)
            {
                this._slodycz = zelki;
            }

            public Slodycz Pierwszy()
            {
                _aktualny = 0;
                return _slodycz[_aktualny] as Slodycz;
            }

            public Slodycz Nastepny()
            {
                _aktualny += _poczatek;
                if (! Zakonczenie)
                    return _slodycz[_aktualny] as Slodycz;
                else
                    return null;
            }

            public Slodycz AktualnySmak
            {
                get { return _slodycz[_aktualny] as Slodycz; }
            }

            public bool Zakonczenie
            {
                get { return _aktualny >= _slodycz.Count; }
            }
        }
        static void Main(string[] args)
        {
            SlodyczCollection collection = new SlodyczCollection();
            collection[0] = new Slodycz("Kwasne");
            collection[1] = new Slodycz("Slodkie");
            collection[2] = new Slodycz("Ostre");
            collection[3] = new Slodycz("Twarde");
            collection[4] = new Slodycz("Lukrecja");
            collection[5] = new Slodycz("Musujace");
            collection[6] = new Slodycz("Slodko kwasne");
            collection[7] = new Slodycz("Cynamonowe");
            collection[8] = new Slodycz("Bez glutenu");

            
            SlodyczIterator iterator = collection.CreateIterator();

            Console.WriteLine("Poprosze wszystko");

            for (Slodycz cukierek = iterator.Pierwszy();
                !iterator.Zakonczenie; cukierek = iterator.Nastepny())
            {
                Console.WriteLine(cukierek.Smak);
            }

        }
    }
}
