# Jogo1-Pirata

Terreno: 
* Arrumei os sprites do terreno da ilha
* Criei um tilemap para eles
* Colisão  
* Composite collider 


Player 
* Objeto com um asset, colisão e rigidbody
* Script com movimentação e pulo, parece q ta não ta muito liso 
* Objeto filho com circle collider para a espada (is trigger) 
* Dano implementado 
* Tentando fazer knockBack 
* Função que confere a direção e inverte o objeto 
** getAxis () e transform.eulerAngles()
* Implementei segundo pulo
* Objeto vazio com trigger dentro do player e compara com tag chão
* Criado um physics material sem atrito para o collider 
* Animações por código


Inimigo
* Modelo base e movimentação em plataforma 
** 2 colliders com o chão 
* Dano e vida implementadas 
* Vai e volta quando recebe dano
* Criei um animator e um classe para trocar as animações



Camera 
* Instalei pacote cinemachine e coloquei pra seguir o player 


Game Manager

UI 
* Criação da barra de vida usando grid e images 
