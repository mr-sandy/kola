import { selectComponent } from '../index';

describe('when selecting a component', () => {
    const template = {
        components: [
            { name: 'a' },
            {
                name: 'b',
                components: [
                    { name: 'b1' },
                    { name: 'b2' },
                    { name: 'b3' }
                ]
            },
            {
                name: 'c',
                areas: [
                    { name: 'c1' },
                    {
                        name: 'c2',
                        components: [
                            { name: 'c2a' },
                            { name: 'c2b' },
                            { name: 'c2c' }
                        ]
                    },
                    { name: 'c3' }
                ]
            }
        ]
    };

    it('should find a direct child', () => {

        const result = selectComponent(template, [0]);

        expect(result.name).toEqual('a');
    });

    it('should find a child of a child container', () => {

        const result = selectComponent(template, [1, 2]);

        expect(result.name).toEqual('b3');
    });

    it('should find an area of a child widget', () => {

        const result = selectComponent(template, [2, 1]);

        expect(result.name).toEqual('c2');
    });

    it('should find a child within a child widget area', () => {

        const result = selectComponent(template, [2, 1, 2]);

        expect(result.name).toEqual('c2c');
    });
});