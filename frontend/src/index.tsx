import React from 'react';
import ReactDOM from 'react-dom/client';
import { TicTacToe } from './App';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

root.render(
  <React.StrictMode>
    <TicTacToe />
  </React.StrictMode>
);
