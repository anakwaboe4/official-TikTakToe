import React, { useState } from 'react';
import { FluentProvider, webLightTheme, webDarkTheme, Theme } from '@fluentui/react-components';
import { Root } from "./components/"

export const TicTacToe: React.FC = () => {
  // State
  const [theme, setTheme] = useState<Theme>(webLightTheme);

  // Functions
  const toggleTheme = () => {
    if (theme === webLightTheme) {
      setTheme(webDarkTheme);
    } else {
      setTheme(webLightTheme);
    }
  }

  return (
    <FluentProvider theme={theme}>
      <Root toggleTheme={toggleTheme} />
    </FluentProvider>
  )
}
