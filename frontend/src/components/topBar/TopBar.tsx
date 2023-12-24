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
                return <WeatherMoon16Regular />
            case webDarkTheme:
                return <WeatherSunny16Filled />
        }
    }

    return (
        <div className={styles.container}>
            <TabList selectedValue={selectedTab} onTabSelect={onSelectedTabChange} className={styles.center}>
                <Tab value={Tabs.Game}>
                    Game
                </Tab>
                <Tab value={Tabs.Settings}>
                    Settings
                </Tab>
            </TabList>
            <Button
                appearance="subtle"
                icon={getThemeIcon()}
                className={styles.right}
                onClick={toggleTheme}
            />
        </div>
    );
}
