# Simulador Gravitacional

Simulador gravitacional 2D desenvolvido para a disciplina **Programação Avançada de Sistemas**, da Faculdade UCL, sob orientação do professor Anker D. Lóss. Projeto de autoria de **Eliezer Novais** e **Victor Alves**.

## O que é o sistema

O simulador distribui aleatoriamente uma quantidade de corpos em uma área e calcula, a cada iteração, a interação gravitacional entre eles: a força que cada corpo exerce sobre os demais, a aceleração resultante e a atualização de posição e velocidade ao longo do tempo. Todas as unidades de medida seguem o Sistema Internacional (SI).

A configuração de um universo (os corpos e seus parâmetros) é gravada automaticamente em um arquivo de texto ao iniciar uma simulação, e pode ser recarregada posteriormente para reproduzir a mesma simulação desde o início.

## Como o universo é modelado

- **Corpo**: cada corpo tem nome, massa, densidade e posição/velocidade nos eixos X e Y. O raio do corpo é derivado da massa e da densidade, a partir da fórmula de volume de uma esfera.
- **Universo**: coordena o conjunto de corpos, calculando a força gravitacional entre cada par, a aceleração resultante e a nova posição de cada corpo a cada iteração.
- **Colisões**: quando dois corpos se encontram, o de maior massa absorve o de menor massa. A massa e a densidade resultantes são combinadas, e a velocidade final é calculada a partir da quantidade de movimento dos dois corpos envolvidos.
- **Persistência**: a gravação e o carregamento de uma simulação são feitos através de uma classe abstrata (`Gravacao`), implementada por uma classe concreta (`GravacaoFilha`) que grava os dados em arquivo de texto. Essa separação permite futuramente trocar o destino dos dados (por exemplo, para um banco de dados) sem alterar o restante do sistema.
- A cada iteração, a posição atual de todos os corpos é exibida na tela.

### Fórmulas utilizadas

- Segunda lei de Newton (F = m·a), para relacionar força, massa e aceleração.
- Lei da gravitação universal, para calcular a força de atração entre cada par de corpos.
- Quantidade de movimento (Q = m·v), usada no cálculo da velocidade resultante de uma colisão.

### Formato do arquivo de gravação

O arquivo é gerado automaticamente ao iniciar uma simulação. A primeira linha identifica o arquivo, a segunda traz os parâmetros gerais e as linhas seguintes descrevem cada corpo:

```
Dados da nova simulação.
Quant. Corpo: <quantidade de corpos>; Quant. Iterações: <quantidade de iterações>; TempoEntreIterações: <tempo entre iterações>
Corpo 1: <Nome: nome>; <Massa: massa>; <Densidade: densidade>; <Posição: (posX, posY)>; <Velocidade: (velX, velY)>
Corpo 2: <Nome: nome>; <Massa: massa>; <Densidade: densidade>; <Posição: (posX, posY)>; <Velocidade: (velX, velY)>
...
```

Ao carregar um arquivo nesse formato, o simulador reconstrói o universo e reproduz a simulação pelo número de iterações registrado.

## Estrutura do projeto

```
SimuladorGravitacional/
├── Corpo.cs                Classe que representa um corpo do universo
├── Universo.cs              Classe que gera os corpos e executa os cálculos da simulação
├── Gravacao.cs              Classe abstrata que define o contrato de gravação de uma simulação
├── GravacaoFilha.cs         Implementação da gravação e do carregamento em arquivo de texto
├── Form1.cs / .Designer.cs  Interface gráfica (Windows Forms)
├── Program.cs               Ponto de entrada da aplicação
├── NomeCorpos.txt           Lista de nomes usada para nomear os corpos gerados aleatoriamente
└── SimuladorGravitacional.csproj
```

## Tecnologias

- C# / .NET 10
- Windows Forms

## Como executar

Pré-requisitos: .NET SDK 10 e Windows (o projeto usa Windows Forms).

```
git clone https://github.com/victorralves/ProgAvantSist---Trabalho-N1---SimuladorGravitacional.git
cd ProgAvantSist---Trabalho-N1---SimuladorGravitacional/SimuladorGravitacional
dotnet run
```

Também é possível abrir `SimuladorGravitacional.slnx` diretamente no Visual Studio.

Na interface, é possível definir a faixa de massa e densidade dos corpos, a quantidade de corpos e o número de iterações antes de iniciar uma simulação, além de carregar uma simulação previamente gravada.
