<br/>
<p align="center">
  <h3 align="center">ScoreBoardLib</h3>

  <p align="center">
    A Recruitment Process Written Library
    <br/>
    <br/>
  </p>
</p>



## Table Of Contents

* [About the Project](#about-the-project)
* [Built With](#built-with)
* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Installation](#installation)
* [Usage](#usage)
* [Contributing](#contributing)
* [Authors](#authors)
* [Acknowledgements](#acknowledgements)

## About The Project

![Screen Shot](https://i.imgur.com/fIo5e0N.jpg)

A Sole Purpose of this project is to demonstrate slight bit of my Programming Skills.

Please bear in mind that I was slightly short on time, and also wanted to Showcase as many C#/.NET related skills as possible.


## Built With

.NET 6
NUnit
Console
ColorfulConsole (Demo Renderer Purposes)


## Getting Started

Since this repository does not drop a NuGet, and there is no Pipelines related, feel free to just clone the repo and play around with it.


### Prerequisites

```git clone https://github.com/ppotepa/ScoreBoardLib.git```

### Installation

Since this is supposed to be a library, I've created a Demo Project inside it's Solution to showcase its capabilities.

Please feel free to use ScoreBoardLibDemo as a Startup Project.
Also you may wanna reference the Library into one of your projects.

## Usage

There are Two Ways of using **ScoreBoardLib**.

Let's start with **Basic Fluid Builder**.

**Basic Fluid Builder**  allows you to Create Starting Instance of ScoreBoard and Configure its Starting Matches.

Following Code will use **VoidRenderer** which means, you are not going to be using any Visual type of Output in your .NET Application.

```
var builder = new ScoreBoardBuilder()
                .UseRenderer<VoidRenderer>();
```

You may also wanna use **DefaultConsoleRenderer** to Visuale Your ScoreBoard Data **(only Valid for Console App purposes, streaming the data out is not suppoted)**

```
var builder = new ScoreBoardBuilder()
                .UseRenderer<DefaultConsoleRenderer>();
```

Also when using the builder you can exactly specify Starting ScoreBoard Matches

```
 builder.UseRenderer<VoidRenderer>()
                    .AddMatch(new Team(Country.EC, 5), new Team(Country.EE, 1), DateTime.Now.AddMinutes(-20))
                    .AddMatch(new Team(Country.PL, 5), new Team(Country.AD, 1), DateTime.Now.AddMinutes(-10))
                    .AddMatch(new Team(Country.QA, 1), new Team(Country.AR, 1), DateTime.Now.AddMinutes(-30))
                    .AddMatch(new Team(Country.NU, 2), new Team(Country.AX, 1), DateTime.Now.AddMinutes(-50));
```

Note... You can easily specify any world region (keep in mind - not all Region are countries) by using Country **Enumeration**
Now we're ready to go.

```
 IScoreBoard board = builder.Build();
```

Once build is called validation is going to occur
In case of wrong validation **SystemInvalidOperationException** is going to be thrown.

To fetch actual game scores just simply go like : 

```
List<Match> scores = board.GetMatchesByScoreDescending();
```

Ordering is hardcoded and there is no way to change the Comparer.

**Depencency Injection**

Simple Dependency Injection was also implemented.
If you feel like using your ScoreBoard as a Service just simply or if using

```
IServiceCollection services = new ServiceCollection();

            services.AddScoreBoard(builder =>
            {
                builder
                    .UseRenderer<ColorfulConsoleRenderer>()
                        .AddMatch(new Team(Country.PL, 0), new Team(Country.CO, 1), DateTime.Now.AddMinutes(-23))
                        .AddMatch(new Team(Country.DE, 1), new Team(Country.GE, 2), DateTime.Now.AddMinutes(-13))
                        .AddMatch(new Team(Country.ID, 2), new Team(Country.UA, 2), DateTime.Now.AddMinutes(-24))
                        .AddMatch(new Team(Country.WF, 1), new Team(Country.BE, 0), DateTime.Now.AddMinutes(-25))
                        .AddMatch(new Team(Country.EE, 0), new Team(Country.EG, 0), DateTime.Now.AddMinutes(-43))
                        .AddMatch(new Team(Country.FI, 0), new Team(Country.GG, 3), DateTime.Now.AddMinutes(-73));
            });

            IServiceProvider provider = services.BuildServiceProvider();
            IScoreBoard scoreBoard = provider.GetService<IScoreBoard>();

            scoreBoard.Start();
```

*!! Please keep in mind ScoreBoard is a SingletonService !!*

**Happy Using**



## Contributing

NOT AVAILABLE
THIS IS FOR RECRUITMENT PURPOSE ONLY

### Creating A Pull Request

NOT AVAILABLE
THIS IS FOR RECRUITMENT PURPOSE ONLY

## Authors

* **Paweł Potępa** - *:)* - [Paweł Potępa](https://github.com/ppotepa/) - *Built ReadME Template - https://readme.shaankhan.dev/*

## Acknowledgements

* [Freddie Mercury](https://www.youtube.com/watch?v=g2N0TkfrQhY)
* [@aragusea - Chicken Soup Dinner Maker](https://www.youtube.com/@aragusea)
* []()

