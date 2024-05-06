import React from 'react'
import GlobalRouter from './routes'
import { ToastBar, Toaster } from 'react-hot-toast'

const App = () => {
  return (
    <div>
      <GlobalRouter />
      <Toaster />
    </div>
  )
}

export default App