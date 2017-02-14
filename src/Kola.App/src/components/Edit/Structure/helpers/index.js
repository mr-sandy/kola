import Atom from '../Atom';
import Container from '../Container';
import Widget from '../Widget';
import { toIntArray } from '../../../../utility';

export const arraysMatch = (arr1, arr2) => {
    if (!arr1 || !arr2) {
        return false
    }

    if (arr1.length !== arr2.length) {
        return false;
    }

    for (let i = 0; i < arr1.length; i++) {
        if (arr1[i] !== arr2[i]) {
            return false;
        }
    }

    return true;
};

export const modifySiblingPath = (sourcePathStr, targetPathStr) => {
    const sourcePath = toIntArray(sourcePathStr);
    const targetPath = toIntArray(targetPathStr);


    // check if the paths are the same depth
    if (sourcePath.length !== targetPath.length) {
        return targetPathStr;
    }

    const sourceWithoutLast = sourcePath.slice(0, sourcePath.length - 1);
    const targetWithoutLast = targetPath.slice(0, targetPath.length - 1);

    // check that they share a parent
    if (!arraysMatch(sourceWithoutLast, targetWithoutLast)) {
        return targetPathStr;
    }

    const lastSource = sourcePath[sourcePath.length - 1];
    const lastTarget = targetPath[targetPath.length - 1];

    var newLast = lastSource < lastTarget
        ? lastTarget - 1
        : lastTarget;

    return '/' + [...sourceWithoutLast, newLast].join('/');
}

const componentMappings = {
    atom: Atom,
    container: Container,
    widget: Widget
}

export const pickComponent = componentType => componentMappings[componentType];