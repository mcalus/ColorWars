﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ColorWars
{
    class BoardField: ISquareDrawable
    {
        private Point position;
        private IPlayer owner;
        private Dictionary<Direction, BoardField> neighbors;
        public event EventHandler PlayerEntered;

        public BoardField(IPlayer player, Point point)
        {
            this.owner = player;
            this.position = point;
            this.neighbors = new Dictionary<Direction, BoardField>();
        }

        public void ChangeOwner(IPlayer newOwner)
        {
            this.owner = newOwner;
        }

        public void AddNeighbor(BoardField field, Direction direction)
        {
            this.neighbors[direction] = field;
        }

        public BoardField GetNeighbor(Direction direction)
        {
            return this.neighbors[direction];
        }

        public Point[] GetPoints()
        {
            return new Point[] {this.position};
        }

        public Color GetColor()
        {
            return ConvertOwnerColor(this.owner.GetColor());
        }

        private Color ConvertOwnerColor(Color color)
        {
            color = new Color(color.R, color.G, color.B);
            color.R = (byte)Math.Floor(color.R * 0.5);
            color.G = (byte)Math.Floor(color.G * 0.5);
            color.B = (byte)Math.Floor(color.B * 0.5);
            color.A = 0;
            return color;
        }
    }
}