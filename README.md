# DM117
Trabalho Final - Unity
Rodrigo Donizetti
Tiago Carvalho
INATEL - Agosto de 2018
Professor Phyllipe Lima

Ladeira Abaixo, usando a Game Engine Unity

"Cormano é um ciclista que já conquistou diversos campeonatos mundiais de Downhill.
Movido pela adrenalina e cansado de não encontrar oponente à altura, esse mito do mundo das descidas
impossíveis está sempre em busca de novas aventuras. Recentemente sua preferida é descer montanhas
desconhecidas e inexploradas em terrenos onde não existem trilhas definidas.
Uma nova descida sempre guarda surpresas, onde algumas destas podem frustrar seus planos e destruir seu
meio de locomoção. Já outras podem inclusive o levar à morte. E são justamente estas que ele busca!
A cada nova experiência concluída, o personagem busca outra que seja ainda mais desafiadora que a
anterior."

O Game Design Document "Ladeira Abaixo" da Disciplina de DM116 foi levado em conta para a construção desse jogo.

O Game Ladeira Abaixo consiste em duas fases:
1) Uma fase de montanha mais estilo floresta, que tem seu boss uma Raposa (FOX)
2) Uma fase de montanha gelada, que tem seu boss um boneco de neve (SNOWMAN)

O player foi representado por uma esfera, para facilitar o desenvolvimento do game.

O cenário foi baixado do Free Asset Store.

O Objetivo do game é chegar ao final da descida da montanha, como diz o GDD.

Na composição do cenário temos:
* Obstáculos => Árvores, Pedras, Montanhas e Galhos/troncos. Se o player ou boss atingirem esses obstáculos, morrem imediatamente.
* Plantas para decorar o ambiente => São apenas componentes de ambiente e não tem função de obstáculo propriamente dito.
Elas estão presentes apenas na primeira fase, que é a mais fácil de ser jogada. Na segunda, temos apenas obstáculos.
* Boss => Uma vez que o player entrou em sua área de atuação, ele inicia a perseguição. Caso o jogador clique com o mouse em cima (ou toque)
ele será destruído. Também é possível matar o boss fazendo movimentos na descida da ladeira e o induzindo a colidir com os obstáculos.
Assim que o Boss colide com o obstáculo, ele é destruído.

Os comandos do jogo são simples: Clique do mouse para destruir o boss, as teclas de seta ou "a", "s", "d" e "w" comandam a movimentação do player.
No caso da versão para o android (arquivo .apk), o movimento é feito através do acelerômetro do celular e mata-se o boss tocando nele.

A qualquer momento o jogo pode ser pausado, clicando no botão no canto inferior esquerdo.

O jogo se inicia na InitialScene, que automaticamente carrega as demais telas e menus. Se for simular o jogo dentro do Unity, comece por ela.

Embora o jogo foi desenvolvido para funcionar com o teclado e mouse, dentro do Script PlayerBehaviour.cs é possível configura-lo para trabalhar com o acelerômetro
e touch do celular. O arquivo apk que esta na pasta do projeto funciona dessa maneira, utilizável a partir do android 4.1. Ao instala-lo, é necessário ativar a opção de 
utilizar aplicativos de fontes desconhecidas.

Na pasta do trabalho, colocamos os relatórios usados, o enunciado do trabalho, o GDD feito em DM116 e o apk do jogo, para que fiquei completa sua documentação.
Para acessar o código fonte, use a pasta Code/ladeiraAbaixo

Itens pedidos no trabalho e forma de implementação:
- Jogo 2D usando a Game engine Unity.
- Entradas: teclado (guia o movimento do player) e mouse (Destroy o boss).
No caso do apk, usamos o acelerômetro para guiar o player e o touch para matar o boss.
- Telas: Tela Inicial, Game Over, Vitória, Botões para reiniciar o jogo e Menu Principal.
- Menus pause completo com resumir, reiniciar e abortar o jogo.
- Colisões com trigger (start e end do boss running, fim da fase, fim do jogo etc) e sem trigger (colisão do player e boss com os obstáculos).
- Uso de RayCast: Ao clicar com o mouse, um ray cast é disparado da posição do player em direção ao clique para ver se existe um boss nessa direção.
Caso exista, o boss será destruído.
- Anúncio simples e com recompensa: O anúncio é exibido (use plataforma que dê recurso de anúncio -> nosso caso android) após a tela de Game Over.
Caso o jogador assistir o anúncio, três árvores do início da MainScene (fase 1) serão destruídas, facilitando a fase e recompensando o jogador.
- Sistema de partículas: ao destruir o boss, ele "explode".
- O jogo possui Áudio de background, áudio na explosão do boss, áudio na transição das telas etc. Apenas a tela vitória não possui áudio.
- Duas cenas diferentes: fase1 (MainScene) e fase 2(MainScene2). Como mencionado acima, mudamo os elementos e a dificuldade da fase.
- Comunicação entre GameObject e troca de mensagens: Feito na hora de matar o boss (Player gera o Ray Cast e manda mensagem para o boss morrer).



