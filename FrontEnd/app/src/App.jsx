import React from 'react'
// import KnapsackProblem from './Components/Find Driver KnapSack/knapsack.jsx'
import {BrowserRouter, Routes,Route} from 'react-router-dom'
import MainPage  from './Pages/MainPage'
import AuthPage  from './Pages/AuthenticationPage'
import Driver  from './Pages/DriverPage'
import Client  from './Pages/ClientPage'
import './App.css'

function App() {
 
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<MainPage/>}/>
        <Route path='/mainpage' element={<MainPage/>}/>
        <Route path='/authpage' element={<AuthPage/>}/>
        <Route path='/driver/:email/:password/:DriverId' element={<Driver/>}/>
        <Route path='/client' element={<Client/>}/>
      </Routes>
    </BrowserRouter>
    
  )
}

export default App
