import { useState } from 'react';
import './App.css'
import Greeting from './components/Greeting'
import LoginButton from './components/LoginButton';
import LogoutButton from './components/LogoutButton';

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const onClick = () =>{
    setIsLoggedIn(prev => !prev);
  }

  return (
    <div style={{margin:'40px'}}>
      <Greeting isLoggedIn={isLoggedIn}/>
      {isLoggedIn ? <LogoutButton onClick={onClick} /> : <LoginButton onClick={onClick} />}
    </div>
  )
}

export default App
