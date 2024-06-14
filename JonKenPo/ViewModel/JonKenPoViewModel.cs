using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using JonKenPo.Model;
using System.Xml.Linq;

namespace JonKenPo.ViewModel
{
    public partial class JonKenPoViewModel : ObservableObject
    {
        public JonKenPoViewModel()
        {
            Jogador = new Jogador(Nome);
            Maquina = new Jogador("Maquina");
            MakeChoiceCommand = new Command (MakeChoice);
        }


        [ObservableProperty]
        private string _nome;

        [ObservableProperty]
        private Jogador _jogador;

        [ObservableProperty]
        private Jogador _maquina;

        [ObservableProperty]
        private Opcao _escolha;

        [ObservableProperty]
        private string _result;

        [ObservableProperty]
        private string _enemyImage;

        [ObservableProperty]
        private string _playerImage;

        [ObservableProperty]
        private int _pontuacao;


        public ICommand MakeChoiceCommand { get; }
        private void MakeChoice()
        {
            Jogador.Nome = Nome;
            Jogador.Escolha = Escolha;
            Maquina.Escolha = (Opcao)new Random().Next(0, 3); //pega os numeros aleatorios da model Escolha
            EnemyImage = $"{Maquina.Escolha}.png";
            PlayerImage = $"{Jogador.Escolha}.png";
            DetermineWinner();
            Pontuacao = Jogador.Pontuacao;
        }
        private void DetermineWinner()
        {
            if (Jogador.Escolha == Maquina.Escolha)
            {
                Jogador.Pontuacao++;
                Maquina.Pontuacao++;
                Result = "Empate!";
            }
            else if((Jogador.Escolha == Opcao.PEDRA && Maquina.Escolha == Opcao.TESOURA)||
                    (Jogador.Escolha == Opcao.PEDRA && Maquina.Escolha == Opcao.PEDRA) ||
                    (Jogador.Escolha == Opcao.PEDRA && Maquina.Escolha == Opcao.PAPEL))
            {           
                Jogador.Pontuacao += 3;
                Result = $"{Jogador.Nome} Venceu!";
            }
            else
            {
                Maquina.Escolha +=3;
                Result = $"{Maquina.Nome} Venceu!";
            }
        }
    }
}
