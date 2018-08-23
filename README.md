# DM117
Trabalho Final - Unity
Rodrigo Donizetti
Tiago Carvalho
INATEL - Agosto de 2018

Ladeira Abaixo

"Cormano é um ciclista que já conquistou diversos campeonatos mundiais de Downhill.
Movido pela adrenalina e cansado de não encontrar oponente à altura, esse mito do mundo das descidas
impossíveis está sempre em busca de novas aventuras. Recentemente sua preferida é descer montanhas
desconhecidas e inexploradas em terrenos onde não existem trilhas definidas.
Uma nova descida sempre guarda surpresas, onde algumas destas podem frustrar seus planos e destruir seu
meio de locomoção. Já outras podem inclusive o levar à morte. E são justamente estas que ele busca!
A cada nova experiência concluída, o personagem busca outra que seja ainda mais desafiadora que a
anterior."

O Game Design Document "Ladeira Abaixo" da Disciplina de DM116 foi levado em conta para a construção desse jogo.

O game consiste em duas fases:
1) Uma fase de montanha mais estilo floresta, que tem seu boss uma Raposa (FOX)
2) Uma fase de montanha gelada, que tem seu boss um boneco de neve (SNOWMAN)

O player foi representado por uma esfera, para facilitar o desenvolvimento do game.

O cenário foi baixado do Asset Store, de itens gratuítos para download.

O Objetivo do game é chegar ao final da descida da montanha, como diz o GDD.

No cenário temos:

* Obstáculos - Árvores, Pedras, Montanhas e Galhos/troncos. Se o player atingir esses obstáculos, morre imediatamente.
* Plantas para decorar o ambiente. São apenas componentes de ambiente e não tem função de obstáculo propriamente dito.
Elas estão presentes apenas na primeira fase, que é a mais fácil de ser jogada.
* Boss. Uma vez que o player entrou em sua área de atuação, ele inicia a perseguição. Caso o jogador clique com o mouse em cima
do boss, ele será destruído. também é possível matar o boss fazendo movimentos e o induzindo a colidir com os obstáculos.

Os comandos do jogo são simples: Mouse para destruir o boss, as teclas de seta ou "a", "s", "d" e "w" comandam a movimentação do player.

A qualquer momento o jogo pode ser pausado, clicando no botão no canto inferior esquerdo.

Itens pedidos no trabalho:
- Jogo 2D usando a Game engine Unity
- Entradas: teclado (guia o movimento do player) e mouse (Destroy o boss).
- Tela Inicial, Game Over, Botões para reiniciar o jogo e Menu Principal
- Menu pause completo com resumir, reiniciar e abortar o jogo.
- Colisões com (start e end do boss running, fim da fase, fim do jogo) e sem trigger (colisão do player e boss com os obstáculos)
- Uso de RayCast -> Ao clicar em cima do boss, um ray cast é disparado para ver se existe um boss nessa direção.
- Anúncio simples e com recompensa (?)
- Sistema de partículas ao destruir o boss, ele "explode".
- Áudio de background, áudio na explosão do boss, áudio na transição das telas.
- Duas cenas diferentes: fase1 (MainScene) e fase 2(MainScene2)
- Comunicação entre GameObject feito na hora de matar o boss (Player gera o Ray Cast e manda mensagem para o boss morrer).


