import { expect } from 'chai';
import { findComponentByPath } from '../../src/actions/helpers/templateHelpers';

const template = {
    iAmTheRoot: true,
    components: [
        {
            type: 'atom',
            name: 'text /0',
            path: '/0'
        },
        {
            type: 'atom',
            name: 'text /1',
            path: '/1'
        },
        {
            type: 'container',
            name: 'div /2',
            path: '/2',
            components: [
                {
                    type: 'atom',
                    name: 'text /2/0',
                    path: '/2/0'
                }
            ]
        },
        {
            type: 'widget',
            name: 'widget /3',
            path: '/3',
            areas: [
                {
                    type: 'atom',
                    name: 'text /3/0',
                    path: '/3/0'
                },
                {
                    type: 'atom',
                    name: 'text /3/1',
                    path: '/3/1'
                }
            ]
        }
    ]
};

describe('when finding a component by its path ', () => {

    it('it should return undefined when no component can be found', () => {
        const result = findComponentByPath(template, '/100/1');

        expect(result).to.equal(undefined);
    });

    it('it should find the root', () => {
        const result = findComponentByPath(template, '/');

        expect(result.iAmTheRoot).to.equal(true);
    });

    it('it should find a top-level component', () => {
        const result = findComponentByPath(template, '/1');

        expect(result.name).to.equal('text /1');
    });

    it('it should find a child component of a container', () => {
        const result = findComponentByPath(template, '/2/0');

        expect(result.name).to.equal('text /2/0');
    });

    it('it should find a child component of a widget', () => {
        const result = findComponentByPath(template, '/3/1');

        expect(result.name).to.equal('text /3/1');
    });
});
