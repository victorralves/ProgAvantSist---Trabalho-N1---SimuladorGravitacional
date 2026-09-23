# Simulador Gravitacional

Simulador gravitacional 2D desenvolvido para a disciplina **Programação Avançada de Sistemas**, da Faculdade UCL, sob orientação do professor Anker D. Lóss. Projeto de autoria de **Eliezer Novais** e **Victor Alves**.

## O que é o sistema

O simulador distribui aleatoriamente uma quantidade de corpos em uma área e calcula, a cada iteração, a interação gravitacional entre eles: a força que cada corpo exerce sobre os demais, a aceleração resultante e a atualização de posição e velocidade ao longo do tempo. Todas as unidades de medida seguem o Sistema Internacional (SI).

A configuração de um universo (os corpos e seus parâmetros) pode ser salva em um arquivo de texto e recarregada posteriormente, permitindo retomar uma simulação exatamente de onde ela parou.

## Como o universo é modelado

- **Corpo**: cada corpo tem nome, massa, densidade e posição/velocidade nos eixos X e Y. O raio do corpo é derivado da massa e da densidade, respeitando o limite físico de densidade máxima que a matéria pode ter.
- **Universo**: coordena o conjunto de corpos, calculando a posição de cada um a cada instante e tratando as colisões que ocorrerem entre eles. No tratamento de colisões, a quantidade de movimento de cada corpo é usada para determinar as velocidades resultantes nos eixos X e Y.
- **Persistência**: a posição inicial dos corpos é gravada em arquivo de texto para permitir a recuperação posterior da simulação. A gravação é feita através de uma classe abstrata, o que permite futuramente trocar o destino dos dados (por exemplo, para um banco de dados) sem alterar o restante do sistema.
- A cada iteração, a situação atual dos corpos é exibida na tela.

### Fórmulas utilizadas

- Segunda lei de Newton (F = m·a), para relacionar força, massa e aceleração.
- Lei da gravitação universal, para calcular a força de atração entre cada par de corpos.
- Quantidade de movimento (Q = m·v), usada no cálculo das velocidades após uma colisão.

### Formato do arquivo de configuração

Primeira linha, com os parâmetros gerais da simulação:

```
<quantidade de corpos>;<quantidade de iterações>;<tempo entre iterações>
```

Demais linhas, uma para cada corpo:

```
<Nome>;<massa>;<densidade>;<PosX>;<PosY>;<VelX>;<VelY>
```

## Estrutura do projeto

```
SimuladorGravitacional/
├── Corpo.cs                Classe que representa um corpo do universo
├── Universo.cs              Classe que gera os corpos e executa os cálculos da simulação
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
