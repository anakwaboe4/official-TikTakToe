import { Button, SelectTabData, SelectTabEvent, Tab, TabList } from "@fluentui/react-components"
import { Lightbulb16Regular, WeatherMoon16Regular } from "@fluentui/react-icons";
import styles from "./TopBar.module.scss";

export const TopBar = (props: {
    toggleTheme: () => void
    selectedTab: string,
    onSelectedTabChange: (event: SelectTabEvent, data: SelectTabData) => void;
}) => {
    const { toggleTheme, selectedTab, onSelectedTabChange } = props;

    return (
        <div className={styles.container}>
            <TabList selectedValue={selectedTab} onTabSelect={onSelectedTabChange} className={styles.center}>
                <Tab id="Game" value="game">
                    Game
                </Tab>
                <Tab id="Settings" value="settings">
                    Settings
                </Tab>
            </TabList>
            <Button
                icon={<WeatherMoon16Regular />}
                className={styles.right}
                onClick={toggleTheme}
            />
        </div>
    );
}
