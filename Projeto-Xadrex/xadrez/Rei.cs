﻿using System;
using tabuleiro;

namespace xadrez
{
    class Rei:Peca
    {
        private PartidaDeXadrez partida;
        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool podemover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }
        private bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.qteMovimentos == 0;
        }
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            //acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            if(tab.posicaoValida(pos)&&podemover(pos))// se tab posicao for verdadeira e receber poder mover
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //nordeste
            pos.definirValores(posicao.linha - 1, posicao.coluna+1);
            if (tab.posicaoValida(pos) && podemover(pos))// se tab posicao for verdadeira e receber poder mover
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //direita
            pos.definirValores(posicao.linha +1, posicao.coluna);
            if (tab.posicaoValida(pos) && podemover(pos))// se tab posicao for verdadeira e receber poder mover
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //Suldeste
            pos.definirValores(posicao.linha +1, posicao.coluna+1);
            if (tab.posicaoValida(pos) && podemover(pos))// se tab posicao for verdadeira e receber poder mover
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //Abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (tab.posicaoValida(pos) && podemover(pos))// se tab posicao for verdadeira e receber poder mover
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //So
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podemover(pos))// se tab posicao for verdadeira e receber poder mover
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podemover(pos))// se tab posicao for verdadeira e receber poder mover
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //no
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podemover(pos))// se tab posicao for verdadeira e receber poder mover
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //#jogadaespecial roque

            if (qteMovimentos == 0 && !partida.xeque)
            {
                //#jogadaespecial roque pequeno
                Posicao PosT1 = new Posicao(posicao.linha, posicao.coluna + 3);
                if (testeTorreParaRoque(PosT1))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);

                    if (tab.peca(p1)==null && tab.peca(p2)==null)
                    {
                        mat[posicao.linha, posicao.coluna + 2] = true;
                    }
                }
                //#jogadaespecial roque grande
                Posicao PosT2 = new Posicao(posicao.linha, posicao.coluna -4);
                if (testeTorreParaRoque(PosT2))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);

                    if (tab.peca(p1) == null && tab.peca(p2) == null&& tab.peca(p3)==null)
                    {
                        mat[posicao.linha, posicao.coluna - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}
