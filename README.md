# DM117
Trabalho Final - Unity
Rodrigo Donizetti
Tiago Carvalho
INATEL - Agosto de 2018
Professor Phyllipe Lima

Ladeira Abaixo, usando a Game Engine Unity

"Cormano � um ciclista que j� conquistou diversos campeonatos mundiais de Downhill.
Movido pela adrenalina e cansado de n�o encontrar oponente � altura, esse mito do mundo das descidas
imposs�veis est� sempre em busca de novas aventuras. Recentemente sua preferida � descer montanhas
desconhecidas e inexploradas em terrenos onde n�o existem trilhas definidas.
Uma nova descida sempre guarda surpresas, onde algumas destas podem frustrar seus planos e destruir seu
meio de locomo��o. J� outras podem inclusive o levar � morte. E s�o justamente estas que ele busca!
A cada nova experi�ncia conclu�da, o personagem busca outra que seja ainda mais desafiadora que a
anterior."

O Game Design Document "Ladeira Abaixo" da Disciplina de DM116 foi levado em conta para a constru��o desse jogo.

O Game Ladeira Abaixo consiste em duas fases:
1) Uma fase de montanha mais estilo floresta, que tem seu boss uma Raposa (FOX)
2) Uma fase de montanha gelada, que tem seu boss um boneco de neve (SNOWMAN)

O player foi representado por uma esfera, para facilitar o desenvolvimento do game.

O cen�rio foi baixado do Free Asset Store.

O Objetivo do game � chegar ao final da descida da montanha, como diz o GDD.

Na composi��o do cen�rio temos:
* Obst�culos => �rvores, Pedras, Montanhas e Galhos/troncos. Se o player ou boss atingirem esses obst�culos, morrem imediatamente.
* Plantas para decorar o ambiente => S�o apenas componentes de ambiente e n�o tem fun��o de obst�culo propriamente dito.
Elas est�o presentes apenas na primeira fase, que � a mais f�cil de ser jogada. Na segunda, temos apenas obst�culos.
* Boss => Uma vez que o player entrou em sua �rea de atua��o, ele inicia a persegui��o. Caso o jogador clique com o mouse em cima (ou toque)
ele ser� destru�do. Tamb�m � poss�vel matar o boss fazendo movimentos na descida da ladeira e o induzindo a colidir com os obst�culos.
Assim que o Boss colide com o obst�culo, ele � destru�do.

Os comandos do jogo s�o simples: Clique do mouse para destruir o boss, as teclas de seta ou "a", "s", "d" e "w" comandam a movimenta��o do player.
No caso da vers�o para o android (arquivo .apk), o movimento � feito atrav�s do aceler�metro do celular e mata-se o boss tocando nele.

A qualquer momento o jogo pode ser pausado, clicando no bot�o no canto inferior esquerdo.

O jogo se inicia na InitialScene, que automaticamente carrega as demais telas e menus. Se for simular o jogo dentro do Unity, comece por ela.

Embora o jogo foi desenvolvido para funcionar com o teclado e mouse, dentro do Script PlayerBehaviour.cs � poss�vel configura-lo para trabalhar com o aceler�metro
e touch do celular. O arquivo apk que esta na pasta do projeto funciona dessa maneira, utiliz�vel a partir do android 4.1. Ao instala-lo, � necess�rio ativar a op��o de 
utilizar aplicativos de fontes desconhecidas.

Na pasta do trabalho, colocamos os relat�rios usados, o enunciado do trabalho, o GDD feito em DM116 e o apk do jogo, para que fiquei completa sua documenta��o.
Para acessar o c�digo fonte, use a pasta Code/ladeiraAbaixo

Itens pedidos no trabalho e forma de implementa��o:
- Jogo 2D usando a Game engine Unity.
- Entradas: teclado (guia o movimento do player) e mouse (Destroy o boss).
No caso do apk, usamos o aceler�metro para guiar o player e o touch para matar o boss.
- Telas: Tela Inicial, Game Over, Vit�ria, Bot�es para reiniciar o jogo e Menu Principal.
- Menus pause completo com resumir, reiniciar e abortar o jogo.
- Colis�es com trigger (start e end do boss running, fim da fase, fim do jogo etc) e sem trigger (colis�o do player e boss com os obst�culos).
- Uso de RayCast: Ao clicar com o mouse, um ray cast � disparado da posi��o do player em dire��o ao clique para ver se existe um boss nessa dire��o.
Caso exista, o boss ser� destru�do.
- An�ncio simples e com recompensa: O an�ncio � exibido (use plataforma que d� recurso de an�ncio -> nosso caso android) ap�s a tela de Game Over.
Caso o jogador assistir o an�ncio, tr�s �rvores do in�cio da MainScene (fase 1) ser�o destru�das, facilitando a fase e recompensando o jogador.
- Sistema de part�culas: ao destruir o boss, ele "explode".
- O jogo possui �udio de background, �udio na explos�o do boss, �udio na transi��o das telas etc. Apenas a tela vit�ria n�o possui �udio.
- Duas cenas diferentes: fase1 (MainScene) e fase 2(MainScene2). Como mencionado acima, mudamo os elementos e a dificuldade da fase.
- Comunica��o entre GameObject e troca de mensagens: Feito na hora de matar o boss (Player gera o Ray Cast e manda mensagem para o boss morrer).



