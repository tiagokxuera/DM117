# DM117
Trabalho Final - Unity
Rodrigo Donizetti
Tiago Carvalho
INATEL - Agosto de 2018

Ladeira Abaixo

"Cormano � um ciclista que j� conquistou diversos campeonatos mundiais de Downhill.
Movido pela adrenalina e cansado de n�o encontrar oponente � altura, esse mito do mundo das descidas
imposs�veis est� sempre em busca de novas aventuras. Recentemente sua preferida � descer montanhas
desconhecidas e inexploradas em terrenos onde n�o existem trilhas definidas.
Uma nova descida sempre guarda surpresas, onde algumas destas podem frustrar seus planos e destruir seu
meio de locomo��o. J� outras podem inclusive o levar � morte. E s�o justamente estas que ele busca!
A cada nova experi�ncia conclu�da, o personagem busca outra que seja ainda mais desafiadora que a
anterior."

O Game Design Document "Ladeira Abaixo" da Disciplina de DM116 foi levado em conta para a constru��o desse jogo.

O game consiste em duas fases:
1) Uma fase de montanha mais estilo floresta, que tem seu boss uma Raposa (FOX)
2) Uma fase de montanha gelada, que tem seu boss um boneco de neve (SNOWMAN)

O player foi representado por uma esfera, para facilitar o desenvolvimento do game.

O cen�rio foi baixado do Asset Store, de itens gratu�tos para download.

O Objetivo do game � chegar ao final da descida da montanha, como diz o GDD.

No cen�rio temos:

* Obst�culos - �rvores, Pedras, Montanhas e Galhos/troncos. Se o player atingir esses obst�culos, morre imediatamente.
* Plantas para decorar o ambiente. S�o apenas componentes de ambiente e n�o tem fun��o de obst�culo propriamente dito.
Elas est�o presentes apenas na primeira fase, que � a mais f�cil de ser jogada.
* Boss. Uma vez que o player entrou em sua �rea de atua��o, ele inicia a persegui��o. Caso o jogador clique com o mouse em cima
do boss, ele ser� destru�do. tamb�m � poss�vel matar o boss fazendo movimentos e o induzindo a colidir com os obst�culos.

Os comandos do jogo s�o simples: Mouse para destruir o boss, as teclas de seta ou "a", "s", "d" e "w" comandam a movimenta��o do player.

A qualquer momento o jogo pode ser pausado, clicando no bot�o no canto inferior esquerdo.

Itens pedidos no trabalho:
- Jogo 2D usando a Game engine Unity
- Entradas: teclado (guia o movimento do player) e mouse (Destroy o boss).
- Tela Inicial, Game Over, Bot�es para reiniciar o jogo e Menu Principal
- Menu pause completo com resumir, reiniciar e abortar o jogo.
- Colis�es com (start e end do boss running, fim da fase, fim do jogo) e sem trigger (colis�o do player e boss com os obst�culos)
- Uso de RayCast -> Ao clicar em cima do boss, um ray cast � disparado para ver se existe um boss nessa dire��o.
- An�ncio simples e com recompensa (?)
- Sistema de part�culas ao destruir o boss, ele "explode".
- �udio de background, �udio na explos�o do boss, �udio na transi��o das telas.
- Duas cenas diferentes: fase1 (MainScene) e fase 2(MainScene2)
- Comunica��o entre GameObject feito na hora de matar o boss (Player gera o Ray Cast e manda mensagem para o boss morrer).


