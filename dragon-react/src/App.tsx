import logo from './logo.svg';
import './App.css';
import Line from './components/line/line';
import Login from './components/login/login';
import DragonList from './components/dragon-list/dragon-list';
import DragonApi from './services/dragonApi';
import { useState } from 'react';

function App() {
  const dragonApi = new DragonApi();
  let [isLoggedIn, setIsLoggedIn] = useState(false);

  return (
    <div className="App">
      <header className="App-header">
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
        <img src={logo} className="App-logo" alt="logo" />
      </header>
      <Login dragonApi={dragonApi} isLoggedIn={isLoggedIn} setIsLoggedIn={setIsLoggedIn} />
      {
        isLoggedIn ? <DragonList dragonApi={dragonApi} /> : <div/>
      }
      <Line/>
    </div>
  );
}

export default App;
