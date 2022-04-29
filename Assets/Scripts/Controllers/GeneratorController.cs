using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace Platformer_2D
{
    public class GeneratorController 
    {
        private Tilemap _tilemap;
        private Tile _groundTile;
        private int _mapHeight;
        private int _mapWidth;
        private bool _borders;
        private int _fillPercent;
        private int _factorSmooth;

        private int[,] _map;
        private int countWall = 4;
        private MarshingSquaresController _controller;
        public GeneratorController(GeneratorLevelView view)
        {
            _tilemap = view.Tilemap;
            _groundTile = view.GroundTile;
            _mapHeight = view.MapHeight;
            _mapWidth = view.MapWidth;
            _borders = view.Borders;
            _fillPercent = view.FillPercent;
            _factorSmooth = view.FactorSmooth;
           _map = new int[_mapWidth, _mapHeight];

           
        }
        public void Init()
        {
            FillMap();
            for (int i = 0; i < _factorSmooth; i++)
            {
            SmoothMap();
            }
            _controller = new MarshingSquaresController();
            _controller.GenerateGrid(_map, 1);
            _controller.DrawTilesOnMap(_tilemap, _groundTile);
            //DrawTiles();
        }

        private void FillMap()
        {
            for (int x = 0; x < _mapWidth; x++)
            {
                for(int y = 0; y < _mapHeight; y++)
                {
                    if (x == 0||x == _mapWidth-1||y == 0||y ==_mapHeight - 1)
                    {
                        if(_borders)
                        {
                            _map[x,y] = 1;
                        }

                    }
                    else
                    {
                        _map[x,y] = Random.Range(0,100) < _fillPercent ? 1 : 0;
                    }
                }
            }
        }
        private void SmoothMap()
        {
            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    int neighbour = GetNeighbour(x,y);
                    if(neighbour >countWall)
                    {
                        _map[x, y] = 1;
                    }
                    else if(neighbour <countWall)
                    {
                        _map[x, y] = 0;
                    }
                }
            }
        }
        private int GetNeighbour(int x, int y)
        {
            int neighbourCounter = 0;

            for (int gridX = x-1; gridX <= x+1; gridX++)
            {
                for(int gridY = y-1; gridY <= y+1; gridY++)
                {
                    if(gridX >= 0 && gridX < _mapWidth && gridY >= 0 && gridY < _mapHeight)
                    {
                        if(gridX!=x||gridY!=y)
                        {
                            neighbourCounter+=_map[gridX,gridY];    
                        }
                    }
                    else
                    {
                        neighbourCounter++; 
                    }
                }
            }

            return neighbourCounter;
        }

        private void DrawTiles()
        {
            if(_map == null)
            {
                return;
            }
            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    Vector3Int tilePosition = new Vector3Int(-_mapWidth / 2 + x, -_mapHeight / 2 + y, 0);
                    if(_map[x,y] == 1)
                    {
                        _tilemap.SetTile(tilePosition, _groundTile);
                    }


                }
            }
        }
    }
}