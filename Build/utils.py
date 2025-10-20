import os

def releaseInit():
    folder = os.path.join(os.getcwd(), "Release")
    path = os.path.join(folder, "InfinityPotion.tmod")

    try:
        if not os.path.exists(folder):
            os.makedirs(folder)

        if os.path.exists(path):
            os.remove(path)
    except Exception as e:
        raise e

def releaseCopy():
    try:
        paths = [
            os.path.join(os.path.expanduser("~"), "Documents", "My Games", "Terraria", "tModLoader", "Mods"),
            os.path.join(os.path.expanduser("~"), "문서", "My Games", "Terraria", "tModLoader", "Mods"),
            os.path.join(os.path.expanduser("~"), "OneDrive", "Documents", "My Games", "Terraria", "tModLoader", "Mods"),
            os.path.join(os.path.expanduser("~"), "OneDrive", "문서", "My Games", "Terraria", "tModLoader", "Mods")
        ]

        mod_path = None
        for p in paths:
            if os.path.exists(p):
                mod_path = p
                break

        file = os.path.join(mod_path, "InfinityPotion.tmod")

        output_folder = os.path.join(os.getcwd(), "Release")
        os.makedirs(output_folder, exist_ok=True)
        output_file = os.path.join(output_folder, "InfinityPotion.tmod")

        with open(file, "rb") as fsrc:
            with open(output_file, "wb") as fdst:
                fdst.write(fsrc.read())
    except Exception as e:
        raise e
