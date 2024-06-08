import { Theme } from "@fluentui/react-components"
import { UseSettings } from "./UseSettings";
import { GameSettingForm } from "../../components/gameSettingForm";
import styles from "./Settings.module.scss";

export const Settings = (props: {
    toastControllerId: string;
    theme: Theme;
}) => {
    const {
        toastControllerId,
        theme,
    } = props;

    const {
        saveSettings
    } = UseSettings(toastControllerId);

    return (
        <div
            className={styles.outerDiv}
        >
            <div
                className={styles.innerDiv}
                style={{
                    backgroundColor: theme.colorNeutralBackground3,
                    borderRadius: theme.borderRadiusXLarge,
                }}
            >
                {/*<center><Label onClick={saveSettings} size="large" weight="semibold">TicTacToe Settings</Label></center>*/}
                <GameSettingForm />
                {/*<Divider appearance="strong"><Label onClick={saveSettings} weight="semibold">Global Settings</Label></Divider>*/}
            </div>
        </div>
    )
}