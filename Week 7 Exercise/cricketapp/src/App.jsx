import "./App.css";
import ListofIndianPlayers from "./components/ListofIndianPlayers";
import ListofPlayers from "./components/ListofPlayers";
import Scorebelow70 from "./components/Scorebelow70";
import { EvenPlayers } from "./EvenPlayers";
import { IndianPlayers } from "./IndianPlayers";
import { OddPlayers } from "./OddPlayers";

function App() {
  const players = [
    { name: "Mr. Jack", score: 50 },
    { name: "Mr. Michael", score: 70 },
    { name: "Mr. John", score: 40 },
    { name: "Mr. Ann", score: 61 },
    { name: "Mr. Elisabeth", score: 61 },
    { name: "Mr. Sachin", score: 95 },
    { name: "Mr. Dhoni", score: 100 },
    { name: "Mr. Virat", score: 84 },
    { name: "Mr. Jadega", score: 64 },
    { name: "Mr. Raina", score: 75 },
    { name: "Mr. Rohit", score: 80 },
  ];
  

  var flag = true;
  if (flag === true) {
    return (
      <div>
        <h1> List of Players</h1>
        <ListofPlayers players={players} />
        <hr />
        <h1> List of Players having Scores Less than 70 </h1>
        <Scorebelow70 players={players} />
      </div>
    );
  } else {
    return (
      <div>
        <div>
          <h1> Indian Team </h1>
          <h1> Odd Players </h1>
          {OddPlayers(IndianPlayers)}
          <hr />
          <h1> Even Players</h1>
          {EvenPlayers(IndianPlayers)}
        </div>
        <hr />
        <div>
          <h1> List of Indian Players Merged: </h1>
          <ListofIndianPlayers IndianPlayers={IndianPlayers} />
        </div>
      </div>
    );
  }
}

export default App;
