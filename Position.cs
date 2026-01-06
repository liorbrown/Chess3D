using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess3D
{
    internal class Position
    {
        private int _hight;
        private int _file;
        private int _rank;

        public Position(int hight, int file, int rank)
        {
            this._hight = hight;
            this._file = file;
            this._rank = rank;
        }

        public int getHight() { return this._hight; }
        public int getFile() { return this._file; }
        public int getRank() { return this._rank; }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Position) return false;

            Position other = (Position)obj;

            return (
                this._hight == other._hight &&
                this._file == other._file &&
                this._rank == other._rank
            );
        }

        public override string ToString()
        {
            int hight = this._hight + 1;
            int rank = this._rank + 1;
            char file = (char)(this._file + 'a');

            return ("Hight: " + hight + ", Square: " + file + rank);
        }

    }
}
