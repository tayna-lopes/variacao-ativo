<h1 align="center">Desafio Variacao dos Ativos</h1>
<h4 align="center"> :computer: Desenvolvido por Tayná Lopes</h4>

<h4 align="left">Descrição</h4>

<p>
Este desafio consiste em consultar a variação do preço de um ativo a sua escolha nos últimos 30 pregões. Você deverá apresentar o percentual de variação de preço de um dia para o outro e o percentual desde o primeiro pregão apresentado.
<br />
<br />1 - Consultar o preço do ativo na API do Yahoo Finance (este é um exemplo da consulta do ativo PETR4 https://query2.finance.yahoo.com/v8/finance/chart/PETR4.SA)
<br /> 2 - Armazenar as informações em uma base de dados a sua escolha.
<br /> 3 - Implementar uma API que consulte as informações na sua base de dados, retorne o valor do ativo nos últimos 30 pregões e apresente a variação do preço no período. Você deverá considerar o valor de abertura (chart.result.indicators.quote.open)
<br />4 - Disponibilizar seu código aqui no Github
</p>

<p>
<h4 align="left"> :jigsaw:	Técnologias Usadas</h4>
  <ul>
  <li>ASP .NET CORE 7</li>
  <li>MongoDB</li>
  <li>MongoDB CompassC</li>
</ul>
</p>

<p>
<h4 align="left"> :open_book:	Instruções</h4>
MONGODB
<ol>
  <li>No MongoDb Compass logar com a string de conexão local (geralmente mongodb://localhost:27017)</li>
  <li>Após conectar clicar no icone de :heavy_plus_sign: para criar uma nova base de dados</li>
  <img src="https://github.com/tayna-lopes/variacao-ativo/assets/61235532/95d75b6e-eef3-49af-aaad-f3e6ce9547bc">
  <li>Criar a base de dados com o nome VariacaoAtivo</li>
  <li>Criar a coleçãos com o nome PregaoCollection</li>
  <img src="https://github.com/tayna-lopes/variacao-ativo/assets/61235532/fd4a7265-c815-4d4b-9ad8-ad22848974e2">
  <li>Clicar em "CREATE DATABASE"</li>
</ol>

VISUAL STUDIO
<ol>
  <li>Clonar o repositório no Visual Studio</li>
  <li>Limpar e Buildar a solução</li>
  <li>Executar a solução</li>
</ol>

</p>
