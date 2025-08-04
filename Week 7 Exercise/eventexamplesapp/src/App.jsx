import { useState } from 'react'
import './App.css'

function App() {
  const [value,setValue] = useState(0);
  const [amount, setAmount] = useState(0);
  const [currency, setCurrency] = useState('');

  const handleSubmit = (e) =>{
    e.preventDefault();
    if(currency === "Rupees"){
      alert(`Converting to Euro Amount: ${amount / 101.48}`);
    }
    else{
      alert(`Converting to Rupees Amount: ${amount * 101.48}`);
    }
  }
  return (
    <div>
      <span>{value}</span><br />
      <button onClick={()=>{setValue(prev=>prev+1);alert("Hello! Member1")}}>Increment</button><br />
      <button onClick={()=>setValue(prev=>prev-1)}>Decrement</button><br />
      <button onClick={()=>alert("welcome")}>Say welcome</button><br />
      <button onClick={()=>alert("I was clicked")}>Click on me</button>

      <h1 style={{color:'green',margin:'20px 0'}} >Currency Convertor!!!</h1>
      <form onSubmit={handleSubmit}>
        <label htmlFor="amount">Amount:</label>
        <input type="number" id="amount" name="amount" value={amount} onChange={(e)=>setAmount(e.target.value)}/><br/>
        <label htmlFor="currency">Currency:</label>
        <textarea name="currency" id="currency"  value={currency} onChange={(e)=>setCurrency(e.target.value)}></textarea><br />
        <button type="submit">Submit</button>
      </form>
    </div>
  )
}

export default App
