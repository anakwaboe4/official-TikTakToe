import React, { useState } from 'react';
import { FluentProvider, webLightTheme, webDarkTheme, Theme } from '@fluentui/react-components';
import { Root } from "./components/"
import { getSsoToken, msalAuth } from './auth/msalAuth';

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
  const initializeWebApp = async () => {
    if (!msalAuth.getAccount()) {
      msalAuth.loginRedirect();
    }
  };

  // Effect
  React.useEffect(() => {
    initializeWebApp();
  }, []);

  return (
    <FluentProvider theme={theme}>
      <Root
        theme={theme}
        toggleTheme={toggleTheme}
        apiAccessTokenProvider={getSsoToken}
      />
    </FluentProvider>
  )
}
