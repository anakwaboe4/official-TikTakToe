import { Button, SelectTabData, SelectTabEvent, Tab, TabList, Theme, webDarkTheme, webLightTheme } from "@fluentui/react-components"
import { WeatherSunny16Filled, WeatherMoon16Regular } from "@fluentui/react-icons";
import styles from "./TopBar.module.scss";
import { Tabs } from "../../models";

export const TopBar = (props: {
    theme: Theme,
    toggleTheme: () => void
    selectedTab: Tabs,
    onSelectedTabChange: (event: SelectTabEvent, data: SelectTabData) => void;
}) => {
    const {
        theme,
        toggleTheme,
        selectedTab,
        onSelectedTabChange
    } = props;

    // Functions
    const getThemeIcon = () => {
        switch (theme) {
            default:
            case webLightTheme:
                return <WeatherSunny16Filled />
            case webDarkTheme:
                return <WeatherMoon16Regular />
        }
    }

    return (
        <div className={styles.container}>
            <TabList selectedValue={selectedTab} onTabSelect={onSelectedTabChange} className={styles.center}>
                <Tab id="Game" value={Tabs.Game}>
                    Game
                </Tab>
                <Tab id="Settings" value={Tabs.Settings}>
                    Settings
                </Tab>
            </TabList>
            <Button
                icon={getThemeIcon()}
                className={styles.right}
                onClick={toggleTheme}
            />
        </div>
    );
}
