"use strict";

function MenuOption(props) {
    const { toggled } = AppContext;
    const className = `menu - ${props.type}-option`;
    const delay = toggled ? 200 : 0;
    const styles = {
        transitionDelay: `${delay + 50 * props.index} ms`,
    };
const link = document.createElement("a");
link.href = props.url;
link.className = className;
link.disabled = !toggled;
link.style = styles;

const icon = document.createElement("i");
icon.className = props.icon;

const heading = document.createElement("h3");
heading.className = props.type === "quick" ? "tooltip" : "label";
heading.textContent = props.label;

link.appendChild(icon);
link.appendChild(heading);

return link;
}

function Menu() {
    const { toggled } = AppContext;
    const profileImage = "/Content/img/uploads/placeholder.jpg";

    function getOptions(options, type) {
        return options.map((option, index) => (
            MenuOption({
                key: option.label,
                icon: option.icon,
                index: index,
                label: option.label,
                url: option.url,
                type: type,
            })
        ));
    }

    function getQuickOptions() {
        return getOptions([
            {
                icon: "fa-solid fa-sign-out",
                label: "Logout",
                url: "#",
            },
            {
                icon: "fa-solid fa-moon",
                label: "Theme",
                url: "https://codepen.io/Hyperplexed",
            },
        ], "quick");
    }

    function getFullOptions() {
        return getOptions([
            {
                icon: "fa-solid fa-house",
                label: "Home",
                url: "/Home/Index",
            },
            {
                icon: "fa-solid fa-paw",
                label: "Animali",
                url: "/Animal/Index",
            },
            {
                icon: "fa-solid fa-stethoscope",
                label: "Visite",
                url: "/Appointment/Index",
            },
            {
                icon: "fa-solid fa-pills",
                label: "Magazzino",
                url: "/magazzino/magazzino",
            },
            {
                icon: "fa-solid fa-prescription-bottle-alt",
                label: "Farmacia",
                url: "#",
            },
        ], "full");
    }

    const menu = document.createElement("div");
    menu.id = "menu";
    menu.className = toggled ? "toggled" : "";

    const backgroundWrapper = document.createElement("div");
    backgroundWrapper.id = "menu-background-wrapper";

    const background = document.createElement("div");
    background.id = "menu-background";

    const profileImageElement = document.createElement("img");
    profileImageElement.id = "menu-profile-image";
    profileImageElement.src = profileImage;

    const quickOptions = document.createElement("div");
    quickOptions.id = "menu-quick-options";
    getQuickOptions().forEach((option) => quickOptions.appendChild(option));

    const fullOptions = document.createElement("div");
    fullOptions.id = "menu-full-options";
    getFullOptions().forEach((option) => fullOptions.appendChild(option));

    menu.appendChild(backgroundWrapper);
    backgroundWrapper.appendChild(background);
    menu.appendChild(profileImageElement);
    menu.appendChild(quickOptions);
    menu.appendChild(fullOptions);

    return menu;
}

const AppContext = {
    toggled: false,
};

function App() {
    const handleOnClick = () => {
        AppContext.toggled = !AppContext.toggled;
        renderApp();
    };

    const app = document.createElement("div");
    app.id = "app";

    const menu = Menu();
    app.appendChild(menu);

    const toggleButton = document.createElement("button");
    toggleButton.id = "menu-toggle";
    toggleButton.type = "button";
    toggleButton.addEventListener("click", handleOnClick);

    const toggleIconClass = AppContext.toggled ? "fa-solid fa-xmark-large" : "fa-solid fa-bars-staggered";
    const toggleIcon = document.createElement("i");
    toggleIcon.className = toggleIconClass;

    toggleButton.appendChild(toggleIcon);
    app.appendChild(toggleButton);

    return app;
}

function renderApp() {
    const root = document.getElementById("root");
    const app = App();
    root.innerHTML = "";
    root.appendChild(app);
}

renderApp();